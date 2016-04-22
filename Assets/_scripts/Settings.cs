using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Settings : MonoBehaviour {

    public Slider bgmSlider;
    public Slider fxSlider;
    public Button fxButton;

    public Toggle bgm;
    public Toggle fx;
    bool playedSound = false;
    // Use this for initialization
    void Start() {
        bgmSlider.value = GameManager.instance.bgmSource.volume;
        fxSlider.value = GameManager.instance.fxSource.volume;
        fxButton.onClick.AddListener(HandleFXSliderButtonClickEvent);
    }

    // Update is called once per frame
    void Update() {
        GameManager.instance.bgmSource.volume = bgmSlider.value;
        GameManager.instance.fxSource.volume = fxSlider.value;
        if (bgm.isOn == false)
        {
            MuteBGM();
        }
        else
        {
            UnmuteBGM();
        }
        if (fx.isOn == false)
        {
            MuteFX();
        }
        else
        {
            
            UnmuteFX();
        }
    }

    
    public void MuteBGM()
    {
        GameManager.instance.bgmSource.enabled = false;            
    }
    public void UnmuteBGM()
    {
        GameManager.instance.bgmSource.enabled = true;
    }

    public void MuteFX()
    {
        GameManager.instance.fxSource.enabled = false;
    }
    
    public void UnmuteFX()
    {
        GameManager.instance.fxSource.enabled = true;        
    }

    public void HandleFXSliderButtonClickEvent()
    {
        GameManager.instance.PlaySound(GameManager.instance.fxButton);
    }
}
