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
    private Animator anim = null;
    private Canvas canvas = null;
    private Dropdown setList = null;
    private Dropdown gachaList = null;
    private Button selectGacha = null;
    private GameObject gachaToPlace = null;
    private Player _player = null;
    #endregion

    #region unity lifecycle methods

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        Debug.Assert(canvas != null, "canvas not found.");

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
        Button[] buttons = canvas.GetComponentsInChildren<Button>();
        Button mainMenu = null;
        foreach (Button button in buttons)
        {
            if (button.name == "Select Gacha")
            {
                selectGacha = button;
            }
            else
            {
                mainMenu = button;
            }
        }


        mainMenu.onClick.AddListener(HandleMenuButtonClick);
        selectGacha.onClick.AddListener(HandlePlaceButtonClick);

        Dropdown[] dropdowns = canvas.GetComponentsInChildren<Dropdown>();
        foreach (Dropdown dropdown in dropdowns)
        {
            if (dropdown.name == "Set List")
            {
                setList = dropdown;
            }
            else
            {
                gachaList = dropdown;
            }
        }
        setList.onValueChanged.AddListener(HandleGachaSetSelection);
        gachaList.onValueChanged.AddListener(HandleGachaSelection);

        LoadGachaSetDropDown();
        //ClearSelectionMenu();
    }

    /// <summary>
    /// Clears the gacha selection dropdown, and disables it as well as the select gacha button.
    /// </summary>
    void ClearSelectionMenu()
    {
        List<GachaSet> setCollection = GameManager.Instance.masterGachaSetList;

        setList.value = 0;


        gachaList.ClearOptions();
        gachaList.enabled = false;
        selectGacha.enabled = false;
    }

    /// <summary>
    /// Sets the option items in the Gacha set dropdown, placing a placeholder at index 0
    /// </summary>
    void LoadGachaSetDropDown()
    {
        List<GachaSet> setCollection = GameManager.Instance.masterGachaSetList;
        setList.ClearOptions();
        setList.options.Add(new Dropdown.OptionData("Select Gacha Set"));
        for (int i = 0; i < setCollection.Count; i++)
        {
            GachaSet gachaSet = setCollection[i];
            setList.options.Add(new Dropdown.OptionData(gachaSet.name));
        }

        //note this will fire the onValueChange event and is taken into account there.
        setList.value = 0;
    }

    /// <summary>
    /// Loads the option items in the Gacha select dropdown, placing a placeholder at index 0.
    /// </summary>
    /// <param name="gachaSetIndex"></param>
    void LoadGachaDropDown(int gachaSetIndex)
    {
        gachaList.ClearOptions();
        List<GachaSet> setCollection = GameManager.Instance.masterGachaSetList;
        GachaSet gachaSet = setCollection[gachaSetIndex];
        gachaList.options.Add(new Dropdown.OptionData("Select Gacha"));
        foreach (GameObject gacha in gachaSet.collection)
        {
            gachaList.options.Add(new Dropdown.OptionData(gacha.name));
        }
        gachaList.enabled = true;
        //note this will fire the onValueChange event and is taken into account there.
        gachaList.value = 0;
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
        selectGacha.enabled = true;

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
        GameObject selectedGacha = GameManager.Instance.masterGachaSetList[setList.value - 1].collection[gachaList.value - 1];//subtract one to account for placeholder in dropdown
        gachaToPlace = Instantiate<GameObject>(GameManager.Instance.GetGachaPrefab(new GachaID(setList.value - 1, gachaList.value - 1)));
        gachaToPlace.GetComponent<Gacha>().OnClickEvent.AddListener(HandleGachaOnClickEvent);
        ClearSelectionMenu();
    }

    /// <summary>
    /// moves gacha gameobject with the mouse position until the left mouse button is clicked
    /// </summary>
    private void UpdateGachaDrag()
    {
        if (gachaToPlace != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Ground");
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                gachaToPlace.transform.position = hit.point;
                if (Input.GetMouseButtonDown(0))
                {
                    gachaToPlace = null;
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

    private void HandleGachaOnClickEvent()
    {
        _player.AddCoins(CoinsPerTap);
    }
    



    #endregion
}
