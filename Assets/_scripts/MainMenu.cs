using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Canvas portrait;
    Canvas landscape;
    AudioSource buttonSound;
    
    void Start()
    {
        InitButtonHandlers();
        buttonSound = GetComponent<AudioSource>();
        GameManager.instance.AddOrientationChangeEventListener(HandleScreenOrientationChange);

        InitCanvas();

        

    }

    void OnDestroy()
    {
        GameManager.instance.RemoveOrientationChangeEventListener(HandleScreenOrientationChange);
    }

    public void HandleClick(GameManager.Menus scene)
    {
        
        buttonSound.Play();//sometimes doesn't work if you click multiple times
        GameManager.instance.ChangeScene(scene);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void InitButtonHandlers()
    {


        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            GameManager.Menus scene = GameManager.Menus.MAIN;
            switch (button.name)
            {
                case "Gacha Machines":
                    scene = GameManager.Menus.GACHACHOOSE;
                    break;
                case "Visit Town":
                    scene = GameManager.Menus.TOWN;
                    break;
                case "View Collection":
                    scene = GameManager.Menus.COLLECTION;
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
