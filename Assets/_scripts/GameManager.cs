using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/// <summary>
/// singleton class that is available from every scene (once instantiated in Main Menu scene). 
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
    [Obsolete]
    public List<GachaSet> masterGachaSetList = new List<GachaSet>();
    public GameObject gachaUIPrefab;
    /// <summary>
    /// Accessor property for this class.
    /// </summary>
    public static GameManager Instance;

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
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        _cameraController = GetComponent<CameraContoller>();
        OnZoomComplete = _cameraController.OnZoomComplete;
        OnZoomReturn = _cameraController.OnZoomReturn;
    }
    #endregion

    #region Gacha collection access
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
