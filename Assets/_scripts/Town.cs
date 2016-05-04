using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets._scripts;

public class Town : MonoBehaviour
{
    #region public properties
    public int CoinsPerTap = 5;

    #endregion

    #region private fields
    private Canvas _canvas = null;
    private Dropdown _setList = null;
    private Dropdown _gachaList = null;
    private Button _selectGacha = null;
    private GameObject _gachaToPlace = null;
    private Player _player = null;
    
    #endregion

    #region unity lifecycle methods

    void Start()
    {
        _canvas = FindObjectOfType<Canvas>();
        Debug.Assert(_canvas != null, "_canvas not found.");

        _player = GameManager.Instance.gameObject.GetComponentInChildren<Player>();
        Debug.Assert(_player != null, "player not found.");

        InitMenu();

        //lock to landscape mode
        Screen.orientation = ScreenOrientation.Landscape;
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
    #endregion

    #region GUI
    void InitMenu()
    {
        Button[] buttons = _canvas.GetComponentsInChildren<Button>();
        Button mainMenu = null;
        foreach (Button button in buttons)
        {
            if (button.name == "Select Gacha")
            {
                _selectGacha = button;
            }
            else
            {
                mainMenu = button;
            }
        }


        mainMenu.onClick.AddListener(HandleMenuButtonClick);
        _selectGacha.onClick.AddListener(HandlePlaceButtonClick);

        Dropdown[] dropdowns = _canvas.GetComponentsInChildren<Dropdown>();
        foreach (Dropdown dropdown in dropdowns)
        {
            if (dropdown.name == "Set List")
            {
                _setList = dropdown;
            }
            else
            {
                _gachaList = dropdown;
            }
        }
        _setList.onValueChanged.AddListener(HandleGachaSetSelection);
        _gachaList.onValueChanged.AddListener(HandleGachaSelection);

        LoadGachaSetDropDown();
    }

    /// <summary>
    /// Clears the gacha selection dropdown, and disables it as well as the select gacha button.
    /// </summary>
    void ClearSelectionMenu()
    {
        List<GachaSet> setCollection = GameManager.Instance.masterGachaSetList;

        _setList.value = 0;


        _gachaList.ClearOptions();
        _gachaList.enabled = false;
        _selectGacha.enabled = false;
    }

    /// <summary>
    /// Sets the option items in the Gacha set dropdown, placing a placeholder at index 0
    /// </summary>
    void LoadGachaSetDropDown()
    {
        List<GachaSet> setCollection = GameManager.Instance.masterGachaSetList;
        _setList.ClearOptions();
        _setList.options.Add(new Dropdown.OptionData("Select Gacha Set"));
        for (int i = 0; i < setCollection.Count; i++)
        {
            GachaSet gachaSet = setCollection[i];
            _setList.options.Add(new Dropdown.OptionData(gachaSet.name));
        }

        //note this will fire the onValueChange event and is taken into account there.
        _setList.value = 0;
    }

    /// <summary>
    /// Loads the option items in the Gacha select dropdown, placing a placeholder at index 0.
    /// </summary>
    /// <param name="gachaSetIndex"></param>
    void LoadGachaDropDown(int gachaSetIndex)
    {
        _gachaList.ClearOptions();
        List<GachaSet> setCollection = GameManager.Instance.masterGachaSetList;
        GachaSet gachaSet = setCollection[gachaSetIndex];
        _gachaList.options.Add(new Dropdown.OptionData("Select Gacha"));
        foreach (GameObject gacha in gachaSet.collection)
        {
            _gachaList.options.Add(new Dropdown.OptionData(gacha.name));
        }
        _gachaList.enabled = true;
        //note this will fire the onValueChange event and is taken into account there.
        _gachaList.value = 0;
    }
    #endregion

    #region UI Handlers
    /// <summary>
    /// Gacha Selection dropdown OnValueChange event handler.
    /// </summary>
    /// <param name="value"></param>
    public void HandleGachaSelection(int value)
    {
        //when setting the dropdown value to 0 to clear the 'selected' choice it fires this event, want to ignore it in this case.
        if (value == 0)
        {
            return;
        }
        _selectGacha.enabled = true;

    }

    /// <summary>
    /// Gacha set dropdown OnValueChanged evcent handler.
    /// </summary>
    /// <param name="value"></param>
    public void HandleGachaSetSelection(int value)
    {
        //when setting the dropdown value to 0 to clear the 'selected' choice it fires this event, want to ignore it in this case.
        if (value == 0)
        {
            return;
        }
        LoadGachaDropDown(value - 1);//subtract 1 to account for placeholder in list at index 0 in dropdown
    }

    /// <summary>
    /// gacha select button click event handler.
    /// </summary>
    public void HandlePlaceButtonClick()
    {
        GameObject selectedGacha = GameManager.Instance.masterGachaSetList[_setList.value - 1].collection[_gachaList.value - 1];//subtract one to account for placeholder in dropdown
        _gachaToPlace = Instantiate<GameObject>(GameManager.Instance.GetGachaPrefab(new GachaID(_setList.value - 1, _gachaList.value - 1)));
        _gachaToPlace.GetComponent<Gacha>().OnClick.AddListener(HandleGachaOnClickEvent);
        ClearSelectionMenu();
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
                if (Input.GetMouseButtonDown(0))
                {
                    _gachaToPlace = null;
                }
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
