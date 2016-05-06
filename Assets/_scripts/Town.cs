using System;
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

    #endregion

    #region private fields
    private Canvas _canvas = null;
    private RectTransform _scrollViewContent = null;
    private GameObject _gachaToPlace = null;
    private Player _player = null;
    private List<Player.PlacedGachaData> _placedGachas;
    
    #endregion

    #region unity lifecycle methods

    void Awake()
    {
        _canvas = FindObjectOfType<Canvas>();
        Debug.Assert(_canvas != null, "_canvas not found.");

        foreach (RectTransform child in _canvas.GetComponentsInChildren<RectTransform>())
        {
            if (child.name == "Content")
            {
                _scrollViewContent = child;
            }
        }
        Debug.Assert(_scrollViewContent != null);
        //lock to landscape mode
        Screen.orientation = ScreenOrientation.Landscape;
    }

    void Start()
    {
        _player = Player.Instance;
        _placedGachas = _player.placedInTownGachas;
        InitMenu();
        LoadPlacedGachas();
    }

    void Update()
    {
        UpdateEscapeKey();

        UpdateGachaDrag();


    }

    void OnDestroy()
    {
        Screen.orientation = ScreenOrientation.Landscape;
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
            gachaUI.onGachaDrag.AddListener(GachaDragEventHandler);
            gachaUI.onGachaDrop.AddListener(GachaDropEventHandler);
        }
        ScrollRect scrollRect = _scrollViewContent.GetComponentInParent<ScrollRect>();
        scrollRect.horizontalNormalizedPosition = 0;

    }
    
    #endregion

    #region UI Handlers

    /// <summary>
    /// Handle the Drag event fired by GachaUI object
    /// </summary>
    /// <param name="eventData"></param>
    void GachaDragEventHandler(GachaID draggedGachaId)
    {
         _gachaToPlace = Instantiate<GameObject>(GameManager.Instance.GetGachaPrefab(draggedGachaId));
        _gachaToPlace.GetComponent<Gacha>().ID = draggedGachaId;
        _gachaToPlace.GetComponent<Gacha>().OnClick.AddListener(HandleGachaOnClickEvent);
    }

    /// <summary>
    /// Handle drop event fired by GachaUI
    /// </summary>
    /// <param name="eventData"></param>
    void GachaDropEventHandler(PointerEventData eventData)
    {
        _placedGachas.Add(new Player.PlacedGachaData(_gachaToPlace.GetComponent<Gacha>().ID,  
            _gachaToPlace.transform.position,
            _gachaToPlace.transform.rotation,
            _gachaToPlace.transform.localScale));
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
    private void HandleMenuButtonClick()
    {
        GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
    }

    private void HandleGachaOnClickEvent(Gacha clickedObject)
    {
        _player.AddCoins(CoinsPerTap);
        if (clickedObject.IsAnimated)
        {
            clickedObject.PlayAnimation(Gacha.Animation.Special);

        }
    }
    #endregion


}
