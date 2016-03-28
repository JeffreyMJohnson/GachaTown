using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour {

    public enum Menus { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE }
    public static MenuHandler instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void LoadMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.MAIN);
    }

    public void LoadTown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.TOWN);
    }

    public void LoadBuyGacha()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.GACHA);
    }

    public void LoadSetting()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.SETTING);
    }

    public void LoadChooseMachine()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.GACHACHOOSE);
    }

    public void LoadViewCollection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.COLLECTION);
    }

    public static void Change(Menus aChangeTo)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)aChangeTo);
        //menuState = aChangeTo;
    }
	
}
