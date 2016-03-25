using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour {

    public enum Menus { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE }

    //Menus menuState = 0;

    // Use this for initialization
    void Start ()
    {

    }

    public void LoadMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.MAIN);
    }

    public void LoadTown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.TOWN);
    }

    public void LoadGacha()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.GACHA);
    }

    public void LoadSetting()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.SETTING);
    }

    public void LoadChoose()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.GACHACHOOSE);
    }

    public void LoadCollection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.COLLECTION);
    }

    public static void Change(Menus aChangeTo)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)aChangeTo);
        //menuState = aChangeTo;
    }
	// Update is called once per frame
	void Update ()
    {

        
        //Menus ToChange = menuState;
        //switch (menuState)
        //{
        //    case Menus.SPLASH:
        //        if (Input.anyKey)
        //        {
        //            ToChange = Menus.MAIN;
        //        }
        //        break;
        //    case Menus.MAIN:
        //        break;
        //    case Menus.GACHA:
        //        break;
        //    case Menus.TOWN:
        //        break;
        //    case Menus.COLLECTION:
        //        break;
        //    case Menus.SETTING:
        //        break;
        //    default:
        //        Debug.Log("invalid menuState");
        //        break;
        //}
        //Change(ToChange);

    }
}
