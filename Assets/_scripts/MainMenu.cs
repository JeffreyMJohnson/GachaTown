using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    public UnityEvent orientationChangeEvent;

    private ScreenOrientation currentOrientation;
    Canvas portrait;
    Canvas landscape;



    void Start()
    {
        InitButtonHandlers();

        currentOrientation = Screen.orientation;

        if(orientationChangeEvent == null)
        {
            orientationChangeEvent = new UnityEvent();

        }

        orientationChangeEvent.AddListener(HandleScreenOrientationChange);

        InitCanvas();
       

    }

    public void HandleClick(GameManager.Menus scene)
    {
        GameManager.instance.ChangeScene(scene);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Screen.orientation != currentOrientation)
        {
            currentOrientation = Screen.orientation;
            orientationChangeEvent.Invoke();
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
        if(currentOrientation == ScreenOrientation.Portrait)
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
        Debug.Log(string.Format("Orientation changed. Now - {0}", Screen.orientation));
        SetOrientationCanvas();
    }
    #endregion
}
