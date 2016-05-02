using UnityEngine;
using System.Collections;
//using UnityEditor;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    //as effects are added to the SoundEffects array, this enum needs to be updated as well to match index
    public enum SoundEffect
    {
        BUTTON_PRESS_POP,
        MECHANICAL_KACHUNK,
        MECHANICAL_CLICK,
        MONEY_CLINK,
        MONEY_CHACHING,

    }

    #region public properties
    public AudioClip[] SoundEffects;

    /// <summary>
    /// This array of audio clips need to match order of the GameManager.Scene enum list for correct indexing
    /// </summary>
    [Tooltip("Background music for each scene")]
    public AudioClip[] BackgroundAudio;

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

    public static AudioManager Instance = null;
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
            _soundEffectsSource.PlayOneShot(SoundEffects[(int)effect]);
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
            AudioClip newBackgroundClip = BackgroundAudio[(int)scene];
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

    void Awake()
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


        _backgroundSource = gameObject.AddComponent<AudioSource>();
        _backgroundSource.loop = true;
        _backgroundSource.playOnAwake = false;
        _soundEffectsSource = gameObject.AddComponent<AudioSource>();
        _soundEffectsSource.loop = false;
        _soundEffectsSource.playOnAwake = false;
    }

    #endregion

}






