﻿using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

/// <summary>
/// singleton class that is available from every scene (once instantiated in Main Menu scene). 
/// Acess this class from the static Instance property, do not instantiate your own.
/// eg GameManager.Instance.Foo();
/// </summary>
public class GameManager : MonoBehaviour
{
    public enum Scene { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE, HOW_TO_PLAY }

    #region public properties
    public List<GachaSet> masterGachaSetList = new List<GachaSet>();

    /*
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
    */
    /// <summary>
    /// Accessor property for this class.
    /// </summary>
    public static GameManager Instance;

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
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
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
        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.BUTTON_PRESS_POP);
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
        AudioManager.Instance.BackgroundAudioPlay(scene);
    }

   
    /*
    public void PlayBackgroundMusic(AudioClip music)
    {
        bgmSource.clip = music;
        bgmSource.Play();
    }

    public void PlaySoundEffect(AudioClip effect)
    {
        fxSource.PlayOneShot(effect);
    }



#region volume methods

    public void RaiseVolumeMusic()
    {
        PlaySoundEffect(fxButton);
        bgmSource.volume += .1f;
    }
    public void RaiseVolumeFX()
    {
        PlaySoundEffect(fxButton);
        fxSource.volume += .1f;
    }
    public void LowerVolumeMusic()
    {
        PlaySoundEffect(fxButton);
        bgmSource.volume -= .1f;
    }
    public void LowerVolumeFX()
    {
        PlaySoundEffect(fxButton);
        fxSource.volume -= .1f;
    }
    
#endregion*/

    //todo this needs to find a better home
    public bool IsGachaAnimated(GameObject gachaGameObject)
    {
        SkinnedMeshRenderer mesh = gachaGameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        if (mesh == null)
            return false;
        Animator anim = gachaGameObject.GetComponent<Animator>();
        return (anim == null) || (anim.enabled);
        //animator needs to be enabled/disabled manually in the prefab
    }
}
