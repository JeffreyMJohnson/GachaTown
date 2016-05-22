using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets._scripts;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine.EventSystems;

public class Town : MonoBehaviour
{
    #region public properties
    public int CoinsPerTap = 5;
    public float ScrollviewShrinkStep = .01f;
    [Tooltip("Minimum amount of seconds to calculate random walk cycle (inclusively).")]
    public float minSecondsToWalk = 5;
    [Tooltip("Maximum amount of seconds to calculate random walk cycle (inclusively).")]
    public float maxSecondsToWalk = 10;
    //todo make sure this is set to false for release. only effects editor but no need to run
    public bool drawGizmos = true;
    #endregion

    #region private fields
    private Canvas _canvas = null;
    private RectTransform _scrollView = null;
    private RectTransform _scrollViewContent = null;
    private GameObject _gachaToPlace = null;
    private GameObject _gachaUIToDrop = null;
    private Player _player = null;
    private List<GameObject> _placedGachas = new List<GameObject>();
    private float _maxScrollViewWidth = 0;
    private bool _isPlaceable = false;
    private float _townDistance;
    private Timer _walkTimer = null;

    #endregion

    #region unity lifecycle methods

    private void Awake()
    {
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.name == "Canvas")
            {
                _canvas = canvas;
            }
        }
        Debug.Assert(_canvas != null, "_canvas not found.");

        Button backButton = null;
        Button purgeButton = null;

        foreach (RectTransform child in _canvas.GetComponentsInChildren<RectTransform>())
        {
            switch (child.name)
            {
                case "Content":
                    _scrollViewContent = child;
                    break;
                case "Scroll View":
                    _scrollView = child;
                    break;
                case "Back":
                    backButton = child.GetComponent<Button>();
                    break;
                case "Purge":
                    purgeButton = child.GetComponent<Button>();
                    break;
            }

        }
        Debug.Assert(_scrollViewContent != null, "scroll view content not found.");
        Debug.Assert(_scrollView != null, "scroll view not found.");
        Debug.Assert(backButton != null, "back button not found.");
        Debug.Assert(purgeButton != null, "purge button not found.");
        //lock to landscape mode
        Screen.orientation = ScreenOrientation.Landscape;

        _maxScrollViewWidth = _scrollView.rect.width;

        //set handlers for expand/shrink button
        ExpandShrinkButton button = _scrollView.GetComponentInChildren<ExpandShrinkButton>();
        Debug.Assert(button != null, "could not find ExpandShrinkButton script as child of scroll view.");
        button.OnExpandClick.AddListener(HandleExpandButtonClickEvent);
        button.OnShrinkClick.AddListener(HandleShrinkButtonClickEvent);

        //set handler for back button
        backButton.onClick.AddListener(HandleBackButtonClickEvent);

        purgeButton.onClick.AddListener(HandlePurgeButtonClickEvent);

        _walkTimer = new Timer(UnityEngine.Random.Range(minSecondsToWalk, maxSecondsToWalk));
        _walkTimer.onRaiseAlarmEvent += HandleWalkAnimationTimerAlarmEvent;
    }

    

    private void Start()
    {
        _player = Player.Instance;
        InitMenu();
        LoadPlacedGachas();
        GameManager.Instance.OnZoomComplete.AddListener(HandleCameraZoomCompleteEvent);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth * .5f, Camera.main.pixelHeight * .25f, 0)), out hit))
        {
            _townDistance = hit.distance * .5f;
        }

        if (_placedGachas.Count > 0)
        {
            _walkTimer.Start();
        }
    }

    private void Update()
    {
        UpdateEscapeKey();

        UpdateGachaDrag();

        _walkTimer.Update(Time.deltaTime);
    }

    private void OnDestroy()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        GameManager.Instance.OnZoomComplete.RemoveListener(HandleCameraZoomCompleteEvent);

    }

    /// <summary>
    /// Change to Menu scene when excape key is pressed.
    /// </summary>
    private void UpdateEscapeKey()
    {
        if (GameManager.Instance.IsCameraZooming)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            HandleBackButtonClickEvent();
        }
    }

    /// <summary>
    /// moves gacha gameobject with the mouse position until the left mouse button is clicked
    /// </summary>
    private void UpdateGachaDrag()
    {

        if (_gachaToPlace != null)
        {

            Vector3 colliderSize = _gachaToPlace.GetComponent<Collider>().bounds.size;
            float radius = _gachaToPlace.GetComponent<Gacha>().Size.x * .5f; //Mathf.Max(colliderSize.x, colliderSize.z);
            Vector3 halfExtents = _gachaToPlace.GetComponent<Gacha>().Size * .5f;

            RaycastHit[] hits = Physics.SphereCastAll(Camera.main.ScreenPointToRay(Input.mousePosition), radius, 1000, LayerMask.GetMask("Ground", "Gacha"));


            _isPlaceable = false;
            Vector3 groundHitPoint =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _townDistance));
            foreach (RaycastHit sphereHit in hits)
            {
                //ignore self
                if (sphereHit.collider.gameObject == _gachaToPlace)
                {
                    continue;
                }
                if (sphereHit.collider.gameObject.layer == LayerMask.NameToLayer("Gacha"))
                {
                    _isPlaceable = false;
                    groundHitPoint = sphereHit.point;
                    break;
                }
                if (sphereHit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    _isPlaceable = true;
                    groundHitPoint = sphereHit.point;
                }

            }
            Color gachaColor = _isPlaceable ? Color.green : Color.red;
            _gachaToPlace.GetComponent<Gacha>().ChangeColor(gachaColor);
            _gachaToPlace.transform.position = groundHitPoint;
        }
    }
    #endregion
    
    #region GUI

    private void InitMenu()
    {
        //this linq query returns only unique entries from player collection
        var query =
            from gacha in _player.gachaCollection.Distinct()
            select gacha;
        //clear the scroll view children in case this isn't the first init
        ClearScrollViewContent();

        foreach (GachaID gachaId in query)
        {
            if (!IsPlaced(gachaId))
            {
                GameObject gachaUIInstance = GameManager.Instance.GetGachaUI(gachaId);
                gachaUIInstance.transform.SetParent(_scrollViewContent);
                GachaUI gachaUI = gachaUIInstance.GetComponent<GachaUI>();
                gachaUI.onGachaDrag.AddListener(HandleGachaUIDragEvent);
                gachaUI.onGachaDrop.AddListener(HandleGachaUIDropEvent);
            }
        }
        ScrollRect scrollRect = _scrollViewContent.GetComponentInParent<ScrollRect>();
        scrollRect.horizontalNormalizedPosition = 0;

    }

    private void ClearScrollViewContent()
    {
        foreach (Transform child in _scrollViewContent.GetComponentsInChildren<Transform>())
        {
            if (child != _scrollViewContent.transform)
            {
                Destroy(child.gameObject);
            }

        }
    }
    #endregion

    #region UI Handlers

    private void HandleGachaUIDragEvent(GameObject draggedObject)
    {
        if (GameManager.Instance.IsCameraZooming)
        {
            return;
        }
        GachaUI gachaUIScript = draggedObject.GetComponent<GachaUI>();
        _gachaToPlace = GameObject.Instantiate<GameObject>(GameManager.Instance.GetGachaPrefab(gachaUIScript.ID));
        Gacha gachaScript = _gachaToPlace.GetComponent<Gacha>();
        gachaScript.ID = gachaUIScript.ID;
        gachaScript.OnClick.AddListener(HandleGachaOnClickEvent);
    }

    private void HandleGachaUIDropEvent(PointerEventData eventData)
    {
        if (_isPlaceable)
        {
            _placedGachas.Add(_gachaToPlace);
            _gachaToPlace.GetComponent<Gacha>().ChangeColor(Color.white);
            InitMenu();
            _walkTimer.Start();
        }
        else
        {
            Destroy(_gachaToPlace);
        }
        _gachaToPlace = null;

    }



    private void HandleGachaOnClickEvent(Gacha clickedObject)
    {
        if (GameManager.Instance.IsCameraZooming)
        {
            return;
        }
        if (_gachaToPlace == null)
        {
            _player.AddCoins(CoinsPerTap);
            if (clickedObject.IsAnimated)
            {
                GameManager.Instance.ZoomToGacha(clickedObject.gameObject);
            }
        }

        Debug.Log("size: " + clickedObject.Size);

    }

    private void HandleCameraZoomCompleteEvent(Gacha clickedGacha)
    {
        clickedGacha.PlayAnimation(Gacha.Animation.Special);
    }

    private void HandleExpandButtonClickEvent()
    {
        StartCoroutine(expandScrollView());
    }

    private void HandleShrinkButtonClickEvent()
    {
        StartCoroutine(ShrinkScrollView());
    }

    private void HandleBackButtonClickEvent()
    {
        if (GameManager.Instance.IsCameraZooming)
        {
            return;
        }
        Player.Instance.SaveTownData(_placedGachas.ToArray());
        GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
    }

    private void HandlePurgeButtonClickEvent()
    {

        foreach (GameObject gacha in _placedGachas)
        {
            Destroy(gacha);
        }
        _placedGachas.Clear();
        InitMenu();
        if (GameManager.Instance.IsCameraZooming)
        {
            GameManager.Instance.CameraReturnToOriginal();
        }
    }

    #endregion

    #region coroutines
    private IEnumerator ShrinkScrollView()
    {
        float t = 0;
        while (t <= 1)
        {
            _scrollView.sizeDelta = new Vector2(
                Mathf.Lerp(_maxScrollViewWidth, 0, t),
                _scrollView.sizeDelta.y);
            t += ScrollviewShrinkStep;
            yield return null;
        }
        //edge case for float math equality check.
        _scrollView.sizeDelta = new Vector2(
               0,
               _scrollView.sizeDelta.y);
    }

    private IEnumerator expandScrollView()
    {
        float t = 0;
        while (t <= 1)
        {
            _scrollView.sizeDelta = new Vector2(
                Mathf.Lerp(0, _maxScrollViewWidth, t),
                _scrollView.sizeDelta.y);
            t += ScrollviewShrinkStep;
            yield return null;
        }

    }
    #endregion

    #region Walk Animation
    

    private void HandleWalkCompleteEvent()
    {
        Debug.Log("callback.");
        _walkTimer.AlarmTime = UnityEngine.Random.Range(minSecondsToWalk, maxSecondsToWalk);
        _walkTimer.Reset();
        _walkTimer.Start();
    }

    private void HandleWalkAnimationTimerAlarmEvent()
    {
        
        Transform seeker = GetRandomPlacedWalkableGacha();
        Transform target = GetRandomPlacedGacha(seeker);
        if (seeker == null || target == null)
        {
            return;
        }
        seeker.GetComponent<Gacha>().Walk(target, HandleWalkCompleteEvent);

    }
#endregion

    private void LoadPlacedGachas()
    {
        foreach (Player.PlacedGachaData data in Player.Instance.GetTownData())
        {
            GameObject newGacha = Instantiate<GameObject>(GameManager.Instance.GetGachaPrefab(data.id));
            newGacha.transform.position = data.position;
            newGacha.transform.rotation = data.rotation;
            newGacha.transform.localScale = data.scale;
            Gacha script = newGacha.GetComponent<Gacha>();
            script.OnClick.AddListener(HandleGachaOnClickEvent);
            script.ID = data.id;
            _placedGachas.Add(newGacha);
        }
    }

    private bool IsPlaced(GachaID id)
    {
        return _placedGachas.Any(gacha => gacha.GetComponent<Gacha>().ID == id);
    }

    /// <summary>
    /// Returns Transform of random gacha placed in town that is walkable, else returns null.
    /// </summary>
    /// <returns></returns>
    private Transform GetRandomPlacedWalkableGacha()
    {
        List<Gacha> walkables = _placedGachas.Select(gacha => gacha.GetComponent<Gacha>()).Where(script => script.isWalkable).ToList();
        if (walkables.Count > 2)
        {
            return walkables[UnityEngine.Random.Range(0, walkables.Count - 1)].transform;
        }
        else if (walkables.Count == 1)
        {
            return walkables[0].transform;
        }
        return null;
    }

    /// <summary>
    /// Returns Transform of a random placed gacha that is not the given the seeker gacha.
    /// note if there are less than 2 gachas placed including the seeker, returns null.
    /// </summary>
    /// <param name="seeker"></param>
    /// <returns></returns>
    private Transform GetRandomPlacedGacha(Transform seeker)
    {
        if (seeker == null || _placedGachas.Count < 2)
        {
            return null;
        }
        int circuitBreaker = 100;
        while (circuitBreaker-- > 0)
        {
            int index = UnityEngine.Random.Range(0, _placedGachas.Count);
            Transform random = _placedGachas[index].transform;
            if (random != seeker)
            {
                return _placedGachas[index].transform;
            }
        }
        Debug.Assert(false, "loop circuit breaker broke, something is wrong.");
        return null;
    }
}
