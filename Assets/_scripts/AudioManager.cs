using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.Security.Policy;
//using UnityEditor;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    //as effects are added to the _soundEffectsAudio array, this enum needs to be updated as well to match index
    public enum SoundEffect
    {
        BUTTON_PRESS_POP,
        MECHANICAL_KACHUNK,
        MECHANICAL_CLICK,
        MONEY_CLINK,
        MONEY_CHACHING,
        CAPSULE_OPEN_POP,
        CAPSULE_GACHA_PRESENT
    }

    #region Singleton lazy instantiation logic
    protected AudioManager() { }

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance 'AudioManager" +
                    "' already destroyed on application quit." +
                    " Won't create again - returning null.");
                return null;
            }
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();

                if (FindObjectsOfType<AudioManager>().Length > 1)
                {
                    Debug.LogError("[Singleton] Something went really wrong " +
                            " - there should never be more than 1 singleton!" +
                            " Reopening the scene might fix it.");
                    return _instance;
                }
                if (_instance == null)
                {
                    GameObject audioManager = new GameObject();
                    _instance = audioManager.AddComponent<AudioManager>();

                    audioManager.name = "(singleton) AudioManager";

                    DontDestroyOnLoad(audioManager);
                }
            }
            return _instance;
        }
    }
    #endregion

    #region public properties
    public float BackgroundAudioVolume
    {
        get { return _backgroundVolume; }
        set
        {
            Debug.Assert(value >= 0 && value <= 1.0f, "MasterVolume must be between 0 and 1 inclusively.");

            _backgroundVolume = value;
            _backgroundSource.volume = _backgroundVolume;
        }
    }

    public bool BackgroundAudioMuted
    {
        get { return _backgroundAudioMuted; }
        set
        {
            //this needs to be cached and updated now in case need to play audio
            bool currentMuteState = _backgroundAudioMuted;
            _backgroundAudioMuted = value;
            //if muting and is not currently muted
            if (value && !currentMuteState)
            {
                BackgroundAudioStop();
            }
            //if un muting and currently muted
            else if (!value && currentMuteState)
            {
                BackgroundAudioPlay(GameManager.Instance.CurrentScene);
            }

        }
    }

    public bool IsBackgroundPlaying { get { return _backgroundSource.isPlaying; } }

    /// <summary>
    /// MasterVolume scale for sound effects in relation to master volume
    /// </summary>
    public float SoundEffectsVolume
    {
        get { return _soundEffectsVolume; }
        set
        {
            _soundEffectsVolume = value;
            _soundEffectsSource.volume = _soundEffectsVolume;
        }
    }

    public bool SoundEffectsMuted { get; set; }
    #endregion

    #region public API
    /// <summary>
    /// Play given sound effect once. Note that if the sound effects are muted it will not play.
    /// </summary>
    /// <param name="effect"></param>
    public void SoundEffectsPlay(SoundEffect effect)
    {
        if (!SoundEffectsMuted)
        {
            _soundEffectsSource.PlayOneShot(_soundEffectsAudio[(int)effect]);
        }
    }

    /// <summary>
    /// Play background music for given scene.  Note that if BackgroundAudio is muted, will not play.
    /// If the scene music is the same as playing will not restart the loop.
    /// </summary>
    /// <param name="scene"></param>
    public void BackgroundAudioPlay(GameManager.Scene scene)
    {
        if (!BackgroundAudioMuted)
        {
            AudioClip newBackgroundClip = _backgroundAudio[(int)scene];
            if (_backgroundSource.clip != newBackgroundClip)
            {
                _backgroundSource.clip = newBackgroundClip;
                _backgroundSource.loop = true;
                _backgroundSource.Play();
            }
        }
    }
    #endregion

    #region private fields
    private AudioSource _backgroundSource;
    private AudioSource _soundEffectsSource;
    private float _backgroundVolume = 1.0f;
    private bool _backgroundAudioMuted = false;
    private float _soundEffectsVolume = 1.0f;
    /// <summary>
    /// This array of audio clips need to match order of the GameManager.Scene enum list for correct indexing
    /// </summary>
    private AudioClip[] _backgroundAudio;
    private AudioClip[] _soundEffectsAudio;

    #endregion

    #region private methods


    /// <summary>
    /// Stop background music from playing.
    /// </summary>
    private void BackgroundAudioStop()
    {
        _backgroundSource.Stop();
        _backgroundSource.clip = null;
        _backgroundSource.loop = false;
    }
    #endregion

    #region unity life cycle methods

    private void Awake()
    {
        _backgroundSource = gameObject.AddComponent<AudioSource>();
        _backgroundSource.loop = true;
        _backgroundSource.playOnAwake = false;
        _soundEffectsSource = gameObject.AddComponent<AudioSource>();
        _soundEffectsSource.loop = false;
        _soundEffectsSource.playOnAwake = false;

        LoadBackgroundAudio();
        LoadSFX();

#if DEBUG
        BackgroundAudioMuted = true;
#endif

    }

    private void LoadBackgroundAudio()
    {
        _backgroundAudio = new AudioClip[4];
        _backgroundAudio[0] = Resources.Load<AudioClip>("audio/background/Main Menu");
        _backgroundAudio[1] = Resources.Load<AudioClip>("audio/background/Buy Gacha");
        _backgroundAudio[2] = Resources.Load<AudioClip>("audio/background/Town");
        _backgroundAudio[3] = Resources.Load<AudioClip>("audio/background/Collection");
    }

    private void LoadSFX()
    {
        _soundEffectsAudio = new AudioClip[7];
        _soundEffectsAudio[0] = Resources.Load<AudioClip>("audio/sfx/BUTTON_PRESS_POP");
        _soundEffectsAudio[1] = Resources.Load<AudioClip>("audio/sfx/MECHANICAL_KACHUNK");
        _soundEffectsAudio[2] = Resources.Load<AudioClip>("audio/sfx/MECHANICAL_CLICK");
        _soundEffectsAudio[3] = Resources.Load<AudioClip>("audio/sfx/MONEY_CLINK");
        _soundEffectsAudio[4] = Resources.Load<AudioClip>("audio/sfx/MONEY_CHACHING");
        _soundEffectsAudio[5] = Resources.Load<AudioClip>("audio/sfx/CAPSULE_OPEN_POP");
        _soundEffectsAudio[6] = Resources.Load<AudioClip>("audio/sfx/CAPSULE_GACHA_PRESENT");
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
    private void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    #endregion

}






