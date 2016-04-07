﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Town : MonoBehaviour
{
    Canvas canvas;
    Dropdown setList = null;
    Dropdown gachaList = null;
    private Button selectGacha = null;

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        InitMenu();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
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

    void ClearSelectionMenu()
    {
        List<GachaSet> setCollection = GameManager.instance.gachaSetDB.setList;

        setList.value = 0;

        
        gachaList.ClearOptions();
        gachaList.enabled = false;
        selectGacha.enabled = false;
    }

    void LoadGachaSetDropDown()
    {
        List<GachaSet> setCollection = GameManager.instance.gachaSetDB.setList;
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

    void LoadGachaDropDown(int gachaSetIndex)
    {
        
        List<GachaSet> setCollection = GameManager.instance.gachaSetDB.setList;
        GachaSet gachaSet = setCollection[gachaSetIndex];
        gachaList.options.Add(new Dropdown.OptionData("Select Gacha"));
        foreach (Gacha gacha in gachaSet.collection)
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
        if (value ==0)
        {
            return;
        }
        LoadGachaDropDown(value - 1);//subtract 1 to account for placeholder in list at index 0 in dropdown
    }

    public void HandlePlaceButtonClick()
    {
        Gacha selectedGacha = GameManager.instance.gachaSetDB.setList[setList.value - 1].collection[gachaList.value - 1];//subtract one to account for placeholder in dropdown
        //todo implement the drag / drop to town here
        Debug.Log("Place " + selectedGacha.name + " now.");

        ClearSelectionMenu();
    }

    public void HandleMenuButtonClick()
    {
        GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
    }

}
