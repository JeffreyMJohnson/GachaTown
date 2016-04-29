using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region private fields
    Canvas portrait;
    Canvas landscape;
    //AudioSource audioSource;
    #endregion

    #region unity lifecycle methods
    void Start()
    {
        InitButtonHandlers();
    }

    void Update()
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

    void InitButtonHandlers()
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
