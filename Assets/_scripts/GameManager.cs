using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public enum Menus { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE, HOW_TO_PLAY }


    public static GameManager instance;
    public List<GachaSet> setList = new List<GachaSet>();
    public bool IsPortrait { get { return orientationController.CurrentOrientation == DeviceOrientationController.Orientation.PORTRAIT; } }

    private DeviceOrientationController orientationController = new DeviceOrientationController();
    private Timer sceneChangeTimer = new Timer(.5f);

    class Timer
    {
        public float time;
        public bool isRunning;
        public bool beep;

        private float _currentTime;

        public Timer(float a_time)
        {
            time = a_time;
            _currentTime = 0;
            isRunning = false;
            beep = false;
        }

        public void Start()
        {
            _currentTime = 0;
            isRunning = true;
        }

        public void Stop()
        {
            isRunning = false;
        }

        public void Update()
        {
            if (isRunning)
            {
                if (_currentTime > 0)
                {
                    _currentTime -= Time.deltaTime;
                }
                else
                {
                    Stop();
                    beep = true;
                }
            }
        }
    }


    private void Update()
    {
        orientationController.Update();
        sceneChangeTimer.Update();
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    /// <summary>
    /// Register a callback method that will be called whenever the device orientation changes from portrait
    /// or landscape.
    /// </summary>
    /// <param name="callBack"></param>
    public void AddOrientationChangeEventListener(UnityAction callBack)
    {
        orientationController.OrientationChangeEvent.AddListener(callBack);
    }

    /// <summary>
    /// Un-register a callback method that will be called whenever the device orientation changes from portrait
    /// or landscape.
    /// </summary>
    /// <param name="callBack"></param>
    public void RemoveOrientationChangeEventListener(UnityAction callBack)
    {
        orientationController.OrientationChangeEvent.RemoveListener(callBack);
    }

    public GachaSet GetGachaSet(int setIndex)
    {
        return setList[setIndex];
    }

    public Gacha GetRandomGacha(int setIndex)
    {
        int randomIndex = Random.Range(0, setList[setIndex].collection.Count);
        return setList[setIndex].collection[randomIndex];
    }

    public GameObject GetGachaGameObject(Gacha gacha)
    {
        GameObject newGacha = Instantiate<GameObject>(gacha.basePrefab);
        GachaManager gachaMan = newGacha.GetComponent<GachaManager>();
        gachaMan.SetGachaData(gacha);
        return newGacha;
    }

    public GameObject GetGachaGameObject(int setIndex, int gachaIndex)
    {
        Gacha gacha = setList[setIndex].collection[gachaIndex];
        GameObject newGacha = Instantiate<GameObject>(gacha.basePrefab);
        GachaManager gachaMan = newGacha.GetComponent<GachaManager>();
        gachaMan.SetGachaData(gacha);
        return newGacha;
    }

    public void ChangeScene(Menus scene)
    {
        StartCoroutine(WaitForAudio(scene));
    }

    private IEnumerator WaitForAudio(Menus scene)
    {
        yield return new WaitForSeconds(Constants.SCENE_CHANGE_WAIT_TIME);
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
    }
}
