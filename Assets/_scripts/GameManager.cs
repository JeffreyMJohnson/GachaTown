using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

/// <summary>
/// singleton class that is available from every scene (once instantiated in Main Menu scene). 
/// Acess this class from the static instance property, do not instantiate your own.
/// eg GameManager.instance.Foo();
/// </summary>
public class GameManager : MonoBehaviour
{
    public enum Menus { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE, HOW_TO_PLAY }

    #region public properties
    public List<GachaSet> masterGachaSetList = new List<GachaSet>();

    //Music

    /*                  CODE REVIEW
     * make this private and init at Awake
     */
    public AudioSource audioSource;

    /*                  CODE REVIEW
     * Add tooltip attribute to these so user get's more context.
     */
    [Tooltip("Background music for Main Menu scene.")]
    public AudioClip bgmMainMenu;
    public AudioClip bgmBuyGacha;
    public AudioClip bgmALT;

    public AudioClip FXRotate;
    public AudioClip FXButton;
    public AudioClip FXBuyTwenty;

    /// <summary>
    /// Accessor property for this class.
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// Returns true if the device screen orientation is in portrait mode, else returns false.
    /// </summary>
    public bool IsPortrait { get { return orientationController.CurrentOrientation == DeviceOrientationController.Orientation.PORTRAIT; } }
    #endregion

    #region private fields
    private DeviceOrientationController orientationController = new DeviceOrientationController();
    #endregion

    #region unity lifecycle methods
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
    #endregion

    #region device screen orientation logic
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

    #endregion

    #region Gacha collection access
    /// <summary>
    /// Returns GachaSet object of given index from the MasterGachaCollection
    /// </summary>
    /// <param name="setIndex"></param>
    /// <returns></returns>
    public GachaSet GetGachaSet(int setIndex)
    {
        return masterGachaSetList[setIndex];
    }

    /// <summary>
    /// Returns a GachaID struct that points to the prefab of a random Gacha from the given set index.
    /// NOTE:Use unity's Instantiate<GameObject>(GetGachaPrefab(GachaID)) to instantiate a gameObject from GachaID.
    /// </summary>
    /// <param name="setIndex"></param>
    /// <returns></returns>
    public GachaID GetRandomGacha(int setIndex)
    {
        int randomIndex = Random.Range(0, masterGachaSetList[setIndex].collection.Count);
        return new GachaID(setIndex, randomIndex);
    }

    /// <summary>
    /// returns prefab located at given GachaID data.
    /// </summary>
    /// <param name="gachaID"></param>
    /// <returns></returns>
    public GameObject GetGachaPrefab(GachaID gachaID)
    {
        return masterGachaSetList[gachaID.SetIndex].collection[gachaID.GachaIndex];
    }
    #endregion

    /// <summary>
    /// Global change scene method. Note this adds a pause before scene change to allow for audio playing
    /// </summary>
    /// <param name="scene"></param>
    public void ChangeScene(Menus scene)
    {
        StartCoroutine(WaitForAudio(scene));
    }

    /*                  CODE REVIEW
     * Lack of summary comment. Just simple little explanation, nothing major your name should convey most of info
     */

    public void PlayMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
    }
    public void PlaySound(AudioClip fx)
    {

        audioSource.PlayOneShot(fx);
    }

    public void LoadMainMenu()
    {
        PlaySound(FXButton);
        ChangeScene(Menus.MAIN);
        PlayMusic(bgmMainMenu);
    }
    public void LoadBuyGacha()
    {
        PlaySound(FXButton);
        ChangeScene(Menus.GACHA);
        PlayMusic(bgmBuyGacha);
    }

    public void LoadScene(Menus scene)
    {
        PlaySound(FXButton);
        ChangeScene(scene);
        PlayMusic(bgmMainMenu);
    }

    /*                  CODE REVIEW
     * verify this still needed
     */
     //hack - this is fix for timing problem when firing audio before scene change
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
