using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public enum Menus { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE, HOW_TO_PLAY }

    public struct GachaID
    {
        public int setIndex;
        public int gachaIndex;

        public GachaID(int a_setIndex, int a_gachaIndex)
        {
            setIndex = a_setIndex;
            gachaIndex = a_gachaIndex;
        }
    }


    public List<GachaSet> masterGachaSetList = new List<GachaSet>(); 

    public static GameManager instance;
    public List<GachaSet> setList = new List<GachaSet>();

    public bool IsPortrait { get { return orientationController.CurrentOrientation == DeviceOrientationController.Orientation.PORTRAIT; } }

    private DeviceOrientationController orientationController = new DeviceOrientationController();

    private void Update()
    {
        orientationController.Update();
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    /// <summary>
    /// Register a callback method that will be called whenever the device orientation changes from portrait
    /// or landscape.
    /// </summary>
    /// <param name="callBack"></param>
    public void AddOrientationChangeEventListener(UnityAction callBack)
    {
        orientationController.OrientationChangeEvent.AddListener(callBack);
    }

    /// <summary>
    /// Un-register a callback method that will be called whenever the device orientation changes from portrait
    /// or landscape.
    /// </summary>
    /// <param name="callBack"></param>
    public void RemoveOrientationChangeEventListener(UnityAction callBack)
    {
        orientationController.OrientationChangeEvent.RemoveListener(callBack);
    }

    public GachaSet GetGachaSet(int setIndex)
    {
        return setList[setIndex];
    }

    public GachaID GetRandomGacha(int setIndex)
    {
        int randomIndex = Random.Range(0, setList[setIndex].collection.Count);
        return new GachaID(setIndex, randomIndex);
    }

    public GameObject GetGacha(int setIndex, int gachaIndex)
    {
        GameObject gachaPrefab = setList[setIndex].collection[gachaIndex];
        GameObject newGacha = Instantiate<GameObject>(gachaPrefab);
        return newGacha;
    }

    public void ChangeScene(Menus scene)
    {
        StartCoroutine(WaitForAudio(scene));
    }

    private IEnumerator WaitForAudio(Menus scene)
    {
        yield return new WaitForSeconds(Constants.SCENE_CHANGE_WAIT_TIME);
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
    }
}
