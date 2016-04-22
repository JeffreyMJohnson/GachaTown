using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region private fields
    Canvas portrait;
    Canvas landscape;
    AudioSource audioSource;
    #endregion

    #region unity lifecycle methods
    void Start()
    {
        InitButtonHandlers();
        audioSource = GetComponent<AudioSource>();
        Debug.Assert(audioSource != null, "audiosource component not found.");
        GameManager.instance.AddOrientationChangeEventListener(HandleScreenOrientationChange);

        InitCanvas();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnDestroy()
    {
        GameManager.instance.RemoveOrientationChangeEventListener(HandleScreenOrientationChange);
    }
    #endregion

    #region UI handlers
    public void HandleClick(GameManager.Scene scene)
    {

        audioSource.Play();
        GameManager.instance.ChangeScene(scene);
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
                case "How To Play":
                    continue;
                    //break;
            }
            button.onClick.AddListener(delegate { HandleClick(scene); });

        }
    }
    
    #region Handle Screen Orientation Change
    void InitCanvas()
    {
        Canvas[] canvasSiblings = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvasSiblings)
        {
            if (canvas.name == "Canvas Portrait")
            {
                portrait = canvas;
            }
            else
            {
                landscape = canvas;
            }
        }
        Debug.Assert(landscape != null && portrait != null, "Landscape and Portrait canvas' did not initialize.");
        SetOrientationCanvas();
    }

    void SetOrientationCanvas()
    {

        if (GameManager.instance.IsPortrait)
        {
            portrait.gameObject.SetActive(true);
            landscape.gameObject.SetActive(false);
        }
        else
        {
            portrait.gameObject.SetActive(false);
            landscape.gameObject.SetActive(true);
        }
    }



    void HandleScreenOrientationChange()
    {
        SetOrientationCanvas();
    }
    #endregion
}
