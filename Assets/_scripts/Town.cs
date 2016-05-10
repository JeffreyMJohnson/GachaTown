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
    public GameObject GachaUIPrefab;

    public float ScrollviewShrinkStep = .01f;

    #endregion

    #region private fields
    private Canvas _canvas = null;
    private RectTransform _scrollView = null;
    private RectTransform _scrollViewContent = null;
    private GameObject _gachaToPlace = null;
    private Player _player = null;
    private List<Player.PlacedGachaData> _placedGachas;
    private float _maxScrollViewWidth = 0;

    #endregion

    #region unity lifecycle methods

    void Awake()
    {
        _canvas = FindObjectOfType<Canvas>();
        Debug.Assert(_canvas != null, "_canvas not found.");

        Button backButton = null;

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
            }

        }
        Debug.Assert(_scrollViewContent != null, "scroll view content not found.");
        Debug.Assert(_scrollView != null, "scroll view not found.");
        Debug.Assert(backButton != null, "back button not found.");
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
    }

    void Start()
    {
        _player = Player.Instance;
        _placedGachas = _player.placedInTownGachas;
        InitMenu();
        LoadPlacedGachas();
        GameManager.Instance.OnZoomComplete.AddListener(HandleCameraZoomCompleteEvent);
    }

    void Update()
    {
        UpdateEscapeKey();

        UpdateGachaDrag();

    }

    void OnDestroy()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        GameManager.Instance.OnZoomComplete.RemoveListener(HandleCameraZoomCompleteEvent);
    }


    #endregion
    /// <summary>
    /// Change to Menu scene when excape key is pressed.
    /// </summary>
    private void UpdateEscapeKey()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
        }
    }


    private void LoadPlacedGachas()
    {
        foreach (Player.PlacedGachaData data in _placedGachas)
        {
            GameObject newGacha = Instantiate<GameObject>(GameManager.Instance.GetGachaPrefab(data.id));
            newGacha.transform.position = data.position;
            newGacha.transform.rotation = data.rotation;
            newGacha.transform.localScale = data.scale;
            newGacha.GetComponent<Gacha>().OnClick.AddListener(HandleGachaOnClickEvent);
        }
    }

    #region GUI
    void InitMenu()
    {
        //this linq query returns only unique entries from player collection
        var query =
            from gacha in _player.gachaCollection.Distinct()
            select gacha;


        foreach (GachaID gachaId in query)
        {
            GameObject gachaUIInstance = GameManager.Instance.GetGachaUI(gachaId);
            gachaUIInstance.transform.SetParent(_scrollViewContent);
            GachaUI gachaUI = gachaUIInstance.GetComponent<GachaUI>();
            gachaUI.onGachaDrag.AddListener(HandleGachaUIDragEvent);
            gachaUI.onGachaDrop.AddListener(HandleGachaUIDropEvent);
        }
        ScrollRect scrollRect = _scrollViewContent.GetComponentInParent<ScrollRect>();
        scrollRect.horizontalNormalizedPosition = 0;

    }

    #endregion

    #region UI Handlers

    void HandleGachaUIDragEvent(GameObject draggedObject)
    {
        GachaUI gachaUIScript = draggedObject.GetComponent<GachaUI>();
        _gachaToPlace = GameObject.Instantiate<GameObject>(GameManager.Instance.GetGachaPrefab(gachaUIScript.ID));
        Gacha gachaScript = _gachaToPlace.GetComponent<Gacha>();
        gachaScript.ID = gachaUIScript.ID;
        gachaScript.OnClick.AddListener(HandleGachaOnClickEvent);
    }

    void HandleGachaUIDropEvent(PointerEventData eventData)
    {
        _placedGachas.Add(new Player.PlacedGachaData(_gachaToPlace));
        _gachaToPlace = null;
    }

    /// <summary>
    /// moves gacha gameobject with the mouse position until the left mouse button is clicked
    /// </summary>
    private void UpdateGachaDrag()
    {
        if (_gachaToPlace != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Ground");
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                _gachaToPlace.transform.position = hit.point;
            }
        }
    }

    /// <summary>
    /// return to menu button onclick event handler.
    /// </summary>
    [Obsolete]
    private void HandleMenuButtonClick()
    {
        GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
    }

    private void HandleGachaOnClickEvent(Gacha clickedObject)
    {
        if (_gachaToPlace == null)
        {
            _player.AddCoins(CoinsPerTap);
            if (clickedObject.IsAnimated)
            {
                GameManager.Instance.ZoomToGacha(clickedObject.gameObject);
            }
        }

    }

    private void HandleCameraZoomCompleteEvent(Gacha clickedGacha)
    {
        clickedGacha.PlayAnimation(Gacha.Animation.Special);
    }

    private void HandleExpandButtonClickEvent()
    {
        Debug.Log("Handle expand button click.");
        StartCoroutine(expandScrollView());
    }

    private void HandleShrinkButtonClickEvent()
    {
        Debug.Log("Handle shrink button click.");
        StartCoroutine(ShrinkScrollView());
    }

    private void HandleBackButtonClickEvent()
    {
        GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
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

}
