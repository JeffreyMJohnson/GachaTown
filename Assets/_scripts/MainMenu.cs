using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region unity lifecycle methods

    private void Start()
    {
        InitButtonHandlers();

        //edge case for first load without using gamemanager class
        if (!AudioManager.Instance.BackgroundAudioMuted && AudioManager.Instance &&
            !AudioManager.Instance.IsBackgroundPlaying)
        {
            AudioManager.Instance.BackgroundAudioPlay(GameManager.Scene.MAIN);
        }
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Update()
    {        
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    #endregion

    #region UI handlers
    public void HandleClick(GameManager.Scene scene)
    {

        //audioSource.Play();
        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.BUTTON_PRESS_POP);
        GameManager.Instance.ChangeScene(scene);
    }

    #endregion

    private void InitButtonHandlers()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            GameManager.Scene scene = GameManager.Scene.MAIN;
            switch (button.name)
            {
                case "Gacha Machines":
                    scene = GameManager.Scene.GACHACHOOSE;
                    break;
                case "Visit Town":
                    scene = GameManager.Scene.TOWN;
                    break;
                case "View Collection":
                    scene = GameManager.Scene.COLLECTION;
                    break;
                case "Settings":
                    scene = GameManager.Scene.SETTING;
                    break;
               //case "How To Play":
                    //continue;
                
                    //break;
            }
            button.onClick.AddListener(delegate { HandleClick(scene); });
        }
    }
    
   
}
