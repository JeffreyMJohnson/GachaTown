using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Town : MonoBehaviour
{
    public AnimationClip walk;
    private Animator anim;
    Canvas canvas;
    Dropdown setList = null;
    Dropdown gachaList = null;
    private Button selectGacha = null;
    private GameObject gachaToPlace = null;

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        InitMenu();

        //lock to landscape mode
        Screen.orientation = ScreenOrientation.Landscape;
        anim = GetComponent<Animator>();
    }

    void OnDestroy()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    private GameObject lemur = null;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
        }

        if (gachaToPlace != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                gachaToPlace.transform.position = hit.point;
                if (Input.GetMouseButtonDown(0))
                {
                    gachaToPlace = null;

                    //todo remove this 
                    lemur = GameObject.Find("Lemur");

                }
            }
        }


    }

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
        List<GachaSet> setCollection = GameManager.instance.setList;

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
        List<GachaSet> setCollection = GameManager.instance.setList;
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
        List<GachaSet> setCollection = GameManager.instance.setList;
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
        GameObject selectedGacha = GameManager.instance.setList[setList.value - 1].collection[gachaList.value - 1];//subtract one to account for placeholder in dropdown
        //todo implement the drag / drop to town here

        gachaToPlace = GameManager.instance.GetGacha(setList.value - 1, gachaList.value - 1);

        ClearSelectionMenu();
    }


    /// <summary>
    /// return to menu button onclick event handler.
    /// </summary>
    public void HandleMenuButtonClick()
    {
        GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
    }

}
