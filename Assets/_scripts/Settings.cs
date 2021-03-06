﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Settings : MonoBehaviour
{
    public Slider backgroundMusic;
    public Slider soundEffects;
    public Button soundEffectsHandle;

    public Toggle muteBackground;
    public Toggle muteSoundEffects;


    private void Start()
    {
        backgroundMusic.value = AudioManager.Instance.BackgroundAudioVolume;
        backgroundMusic.onValueChanged.AddListener(HandleBackgroundVolumeOnValueChangeEvent);

        soundEffects.value = AudioManager.Instance.SoundEffectsVolume;
        soundEffects.onValueChanged.AddListener(HandleSoundEffectsVolumeOnValueChangedEvent);

        soundEffectsHandle.onClick.AddListener(HandleSoundEffectsSliderButtonClickEvent);

        muteBackground.isOn = AudioManager.Instance.BackgroundAudioMuted;
        muteBackground.onValueChanged.AddListener(HandleBackgroundMuteOnValueChangeEvent);

        muteSoundEffects.isOn = AudioManager.Instance.SoundEffectsMuted;
        muteSoundEffects.onValueChanged.AddListener(HandleSoundEffectsMuteOnValueChangeEvent);

        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
        }
    }

    private void HandleBackgroundVolumeOnValueChangeEvent(float value)
    {
        AudioManager.Instance.BackgroundAudioVolume = value;
    }

    private void HandleSoundEffectsVolumeOnValueChangedEvent(float value)
    {
        AudioManager.Instance.SoundEffectsVolume = value;
    }

    private void HandleBackgroundMuteOnValueChangeEvent(bool value)
    {
        AudioManager.Instance.BackgroundAudioMuted = value;
    }

    private void HandleSoundEffectsMuteOnValueChangeEvent(bool value)
    {
        AudioManager.Instance.SoundEffectsMuted = value;
    }

    public void HandleSoundEffectsSliderButtonClickEvent()
    {
        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.BUTTON_PRESS_POP);
    }
}
