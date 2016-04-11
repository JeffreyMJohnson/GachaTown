using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public enum Menus { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE, HOW_TO_PLAY }

   


    public List<GachaSet> masterGachaSetList = new List<GachaSet>(); 

    public static GameManager instance;
    //public List<GachaSet> setList = new List<GachaSet>();

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

    /*
     * this doesn't belong in this class
    public bool DoesPlayerHave(string gachaName)
    {
        if (GameObject.Find(gachaName) == null)
            return false;
        else
            return true;
    }
    */
    public GachaSet GetGachaSet(int setIndex)
    {
        return masterGachaSetList[setIndex];
    }

    public GachaID GetRandomGacha(int setIndex)
    {
        int randomIndex = Random.Range(0, masterGachaSetList[setIndex].collection.Count);
        return new GachaID(setIndex, randomIndex);
    }

    /// <summary>
    /// returns prefab of gachaName of given set and gachaName index.
    /// </summary>
    /// <param name="setIndex"></param>
    /// <param name="gachaIndex"></param>
    /// <returns></returns>
    public GameObject GetGachaPrefab(int setIndex, int gachaIndex)
    {
        return masterGachaSetList[setIndex].collection[gachaIndex];
    }

    public string GetGachaName(int setIndex, int gachaIndex)
    {
        if (gachaIndex > masterGachaSetList[setIndex].collection.Count - 1)
            gachaIndex = masterGachaSetList[setIndex].collection.Count - 1;
        return masterGachaSetList[setIndex].collection[gachaIndex].name;
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

    //todo this needs to find a better home
    public bool IsGachaAnimated(GameObject gachaGameObject)
    {
        Animator anim = gachaGameObject.GetComponent<Animator>();
        return (anim == null) || (anim.enabled);
    }

}
