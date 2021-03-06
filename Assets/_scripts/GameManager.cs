﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/// <summary>
/// singleton class that is available from every scene 
/// Acess this class from the static Instance property, do not instantiate your own.
/// eg GameManager.Instance.Foo();
/// </summary>
public class GameManager : MonoBehaviour
{
    public enum Scene { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE, HOW_TO_PLAY }

    #region public properties

    public bool IsCameraZooming
    {
        get { return _cameraController.IsZooming; }
    }

    #region Singleton lazy instantiation logic
    //protected GameManager() { }

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance 'GameManager" +
                    "' already destroyed on application quit." +
                    " Won't create again - returning null.");
                return null;
            }
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (FindObjectsOfType<GameManager>().Length > 1)
                {
                    Debug.LogError("[Singleton] Something went really wrong " +
                            " - there should never be more than 1 singleton!" +
                            " Reopening the scene might fix it.");
                    return _instance;
                }
                if (_instance == null)
                {
                    GameObject gameManager = new GameObject();
                    gameManager.AddComponent<CameraContoller>();
                    _instance = gameManager.AddComponent<GameManager>();

                    gameManager.name = "(singleton) GameManager";

                    DontDestroyOnLoad(gameManager);
                }
            }
            return _instance;
        }
    }

    private static bool applicationIsQuitting = false;
    /// <summary>
	/// When Unity quits, it destroys objects in a random order.
	/// In principle, a Singleton is only destroyed when application quits.
	/// If any script calls Instance after it have been destroyed, 
	///   it will create a buggy ghost object that will stay on the Editor scene
	///   even after stopping playing the Application. Really bad!
	/// So, this was made to be sure we're not creating that buggy ghost object.
	/// </summary>
	public void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    #endregion

    public Scene CurrentScene { get { return _currentScene; } private set { _currentScene = value; } }

    public CameraContoller.CameraZoomCompleteEvent OnZoomComplete;
    public UnityEvent OnZoomReturn;
    #endregion

    #region private fields

    //private DeviceOrientationController orientationController = new DeviceOrientationController();
    private Scene _currentScene;
    private CameraContoller _cameraController;
    #endregion

    #region unity lifecycle methods

    private void Awake()
    {
       _cameraController = GetComponent<CameraContoller>();
        OnZoomComplete = _cameraController.OnZoomComplete;
        OnZoomReturn = _cameraController.OnZoomReturn;
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

    /// <summary>
    /// Zoom the current camera to closeup on given gacha
    /// </summary>
    /// <param name="gacha"></param>
    public void ZoomToGacha(GameObject gacha)
    {
        _cameraController.Closeup(gacha);
    }

    /// <summary>
    /// Return the zoomed camera to original position and rotation.
    /// </summary>
    public void CameraReturnToOriginal()
    {
        _cameraController.PullBackToOriginal();
    }

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
