﻿using System;
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
    private GameObject _gachaUIToDrop = null;
    private Player _player = null;
    private List<GameObject> _placedGachas = new List<GameObject>();
    private float _maxScrollViewWidth = 0;
    private bool _isPlaceable = false;
    private Material _redMaterial;
    private Material _greenMaterial;


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

        _redMaterial = Resources.Load<Material>("materials/red");
        _greenMaterial = Resources.Load<Material>("materials/green");
        Debug.Assert(_redMaterial != null, "could not find red material in resources.");
        Debug.Assert(_greenMaterial != null, "could not find green material in resources.");
    }

    private float _townDistance;
    void Start()
    {
        _player = Player.Instance;
        InitMenu();
        LoadPlacedGachas();
        GameManager.Instance.OnZoomComplete.AddListener(HandleCameraZoomCompleteEvent);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth * .5f, Camera.main.pixelHeight * .25f, 0)), out hit))
        {
            _townDistance = hit.distance;
        }
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
            HandleBackButtonClickEvent();
        }
    }


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
    #region GUI
    void InitMenu()
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
        if (_isPlaceable)
        {
            _placedGachas.Add(_gachaToPlace);
            _gachaToPlace.GetComponent<Gacha>().ChangeColor(Color.white);
            InitMenu();
        }
        else
        {
            Destroy(_gachaToPlace);
        }
        _gachaToPlace = null;

    }

    /// <summary>
    /// moves gacha gameobject with the mouse position until the left mouse button is clicked
    /// </summary>
    private void UpdateGachaDrag()
    {

        if (_gachaToPlace != null)
        {

            Vector3 colliderSize = _gachaToPlace.GetComponent<Collider>().bounds.size;
            float radius = Mathf.Max(colliderSize.x, colliderSize.z);
            RaycastHit[] hits = Physics.SphereCastAll(Camera.main.ScreenPointToRay(Input.mousePosition), radius, 1000, LayerMask.GetMask("Ground", "Gacha"));

            _isPlaceable = false;
            Vector3 groundHitPoint = Vector3.zero;
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
                    break;
                }
                if (sphereHit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    _isPlaceable = true;
                    groundHitPoint = sphereHit.point;
                }

            }



            if (_isPlaceable)
            {
                _gachaToPlace.GetComponent<Gacha>().ChangeColor(Color.green);
                _gachaToPlace.transform.position = groundHitPoint;
            }
            else
            {
                _gachaToPlace.GetComponent<Gacha>().ChangeColor(Color.red);
                _gachaToPlace.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                    _townDistance));
            }
        }
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
        StartCoroutine(expandScrollView());
    }

    private void HandleShrinkButtonClickEvent()
    {
        StartCoroutine(ShrinkScrollView());
    }

    private void HandleBackButtonClickEvent()
    {
        Player.Instance.SaveTownData(_placedGachas.ToArray());
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

    private bool IsPlaced(GachaID id)
    {
        return _placedGachas.Any(gacha => gacha.GetComponent<Gacha>().ID == id);
    }

}
