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
    public enum Scene { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE, HOW_TO_PLAY }

    #region public properties
    public List<GachaSet> masterGachaSetList = new List<GachaSet>();

    //Music
    public AudioSource bgmSource;
    public AudioSource fxSource;

    public AudioClip bgmMainMenu;
    public AudioClip bgmBuyGacha;
    public AudioClip bgmALT;

    public AudioClip fxRotate;
    public AudioClip fxButton;
    public AudioClip fxBuyTwenty;
    public bool isMutedBGM = false;
   public bool isMutedFX = false;
    /// <summary>
    /// Accessor property for this class.
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// Returns true if the device screen orientation is in portrait mode, else returns false.
    /// </summary>
    public bool IsPortrait { get { return orientationController.CurrentOrientation == DeviceOrientationController.Orientation.PORTRAIT; } }
    public Scene CurrentScene { get { return _currentScene; } private set { _currentScene = value; } }

    #endregion

    #region private fields
    private DeviceOrientationController orientationController = new DeviceOrientationController();
    private Scene _currentScene;
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
    public void ChangeScene(Scene scene)
    {
        CurrentScene = scene;
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
        //StartCoroutine(WaitForAudio(scene));

    }

    public void PlayMusic(AudioClip music)
    {
        
            bgmSource.clip = music;
            bgmSource.Play();
        
        
    }
    public void PlaySound(AudioClip fx)
    {
        
            fxSource.PlayOneShot(fx);
        
        
    }

    public void LoadMainMenu()
    {
        PlaySound(fxButton);
        ChangeScene(Menus.MAIN);
        PlayMusic(bgmMainMenu);
    }
    public void LoadBuyGacha()
    {
        PlaySound(fxButton);
        ChangeScene(Menus.GACHA);
        PlayMusic(bgmBuyGacha);
    }
    public void LoadSettings()
    {
        PlaySound(fxButton);
        ChangeScene(Menus.SETTING);
    }

    public void LoadScene(Menus scene)
    {
        PlaySound(fxButton);
        ChangeScene(scene);
        PlayMusic(bgmMainMenu);

    //Volume functions
    
    public void RaiseVolumeMusic()
    {
        PlaySound(fxButton);
        bgmSource.volume += .1f;      
    }
    public void RaiseVolumeFX()
    {
        PlaySound(fxButton);
        fxSource.volume += .1f;        
    }  
    public void LowerVolumeMusic()
    {
        PlaySound(fxButton);
        bgmSource.volume -= .1f; 
    }
    public void LowerVolumeFX()
    {
        PlaySound(fxButton);
        fxSource.volume -= .1f;      
    }

    //todo this needs to find a better home
    public bool IsGachaAnimated(GameObject gachaGameObject)
    {
        Animator anim = gachaGameObject.GetComponent<Animator>();
        return (anim == null) || (anim.enabled);
        //animator needs to be enabled/disabled manually in the prefab
    }
}
