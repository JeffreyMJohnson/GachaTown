using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GachaRotator : MonoBehaviour
{

    //all you have to do is slap a gacha machine object as a child of this one, make sure they're all in the same place
    #region public properties
    public Text gachaDisplay;
    public Text moneyDisplay;
    public int selectedGacha = 0;
    public int rotateTime = 15; //in frames
    public int swipeLength = 200;
    #endregion

    #region private fields
    private List<SpriteRenderer> titleImages = new List<SpriteRenderer>();
    private int maxGachaSetCount;
    private GameObject[] gachaMachines;
    private Transform[] gachaTransforms;
    private float rotationInterval = 0;
    private int rotateStart = 15;
    private Player playerScript;
    private int gachaCount = 0;
    private int rotateQueue = 0;
    private int dragStart;
    private int dragCurrent;
    private bool isSwipe;
    #endregion

    #region unity lifecycle methods

    private void Start()
    {
        //GameObject playerObject = Player.Instance.gameObject;

        playerScript = Player.Instance;

        dragStart = 0;
        dragCurrent = 0;
        isSwipe = false;

        selectedGacha = playerScript.Selected;
        Debug.Assert(moneyDisplay != null, "Money text component not found, set in editor?");
        moneyDisplay.text = playerScript.TotalCoins.ToString();

        Debug.Assert(gachaDisplay != null, "gacha display text component not found, set in editor ?");

        SpriteRenderer[] titleImagesToList = gachaDisplay.GetComponentsInChildren<SpriteRenderer>(true);

        foreach (SpriteRenderer spriterenderer in titleImagesToList)
        {
            spriterenderer.enabled = false;
            titleImages.Add(spriterenderer);
        }
        titleImages[selectedGacha].enabled = true;

        rotateStart = rotateTime;

        gachaMachines = new GameObject[transform.childCount];
        gachaTransforms = new Transform[transform.childCount];
        foreach (Transform child in transform)
        {
            gachaTransforms[gachaCount] = child;
            gachaMachines[gachaCount] = child.gameObject;
            gachaCount++;
        }

        rotationInterval = 360 / gachaCount;

        for (int i = 0; i < gachaCount; i++)
        {
            gachaTransforms[i].Rotate(0, rotationInterval * i, 0);
        }

        for (int i = 0; i < selectedGacha; i++)
        {
            transform.Rotate(0, -rotationInterval, 0);
        }
        TextUpdate();

        maxGachaSetCount = GameManager.Instance.masterGachaSetList.Count;

        Screen.orientation = ScreenOrientation.Portrait;

        //This looks dumb (and it is) but it works for now
        //the machine that is initially displayed is not correct and I do not want to mess with the start logic
        RotateRight();
        HandleQueue();
        while (rotateStart < rotateTime)
        {
            rotateStart++;
            transform.Rotate(0, Mathf.Lerp(transform.eulerAngles.y, GetDestinationRotation(), (float)rotateStart / (float)rotateTime) - transform.eulerAngles.y, 0);
        }
        RotateLeft();
        HandleQueue();
        while (rotateStart < rotateTime)
        {
            rotateStart++;
            transform.Rotate(0, Mathf.Lerp(transform.eulerAngles.y, GetDestinationRotation(), (float)rotateStart / (float)rotateTime) - transform.eulerAngles.y, 0);
        }

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
        }

        if (Input.GetMouseButtonDown(0))
        {
            dragStart = (int)Input.mousePosition.x;
            dragCurrent = (int)Input.mousePosition.x;
            isSwipe = true;
        }
        if (Input.GetMouseButtonUp(0)) //change this to when the mouse releases, edge case for dragging on to it after swiping
        {
            if (isSwipe)
            {
                isSwipe = false;
                dragCurrent = 0;
                dragStart = 0;
            }
        }

        if (Input.GetMouseButton(0) && isSwipe)
        {
            dragCurrent = (int)Input.mousePosition.x;
            if (dragCurrent - dragStart > swipeLength)
            {
                dragStart += swipeLength;
                RotateLeft();
                isSwipe = !isSwipe;
            }
            else if (dragCurrent - dragStart < -swipeLength)
            {
                dragStart -= swipeLength;
                RotateRight();
                isSwipe = !isSwipe;
            }
        }

        HandleQueue();

        if (rotateStart < rotateTime)
        {
            //bug add deltaTime for timing not frame count.  if you want frame count use an int
            RotateHolder();

        }

    }
    #endregion

    private void RotateHolder()
    {
        rotateStart++;

        transform.Rotate(0, Mathf.Lerp(transform.eulerAngles.y, GetDestinationRotation(), (float)rotateStart / (float)rotateTime) - transform.eulerAngles.y, 0);
    }

    private void TextUpdate()
    {
        gachaDisplay.text = "MACHINE NO. " + (selectedGacha + 1) + "\nCOST 5\n" + GameManager.Instance.masterGachaSetList[selectedGacha].name;
    }

    /// <summary>
    /// decrease gacha set index
    /// </summary>
    public void RotateLeft()
    {
        rotateQueue--;
    }

    /// <summary>
    /// decrease gacha set index
    /// </summary>
    public void RotateRight()
    {
        rotateQueue++;        
    }

    public void HandleQueue()
    {
        if (rotateQueue > 0)
        {
            if (rotateStart == rotateTime)
            {
                rotateQueue--;
                rotateStart = 0;

                selectedGacha++;

                //if (selectedGacha == -1)
                //    selectedGacha = gachaCount - 1;
                //selectedGacha = selectedGacha % gachaCount;
                if (selectedGacha == maxGachaSetCount)
                {
                    selectedGacha = 0;
                }

                for (int i = 0; i < titleImages.Count; i++)
                {
                    titleImages[i].enabled = false;
                }
                titleImages[selectedGacha].enabled = true;

                TextUpdate();
                AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.MECHANICAL_CLICK);
            }
        }
        if (rotateQueue < 0)
        {
            if (rotateStart == rotateTime)
            {
                rotateQueue++;
                rotateStart = 0;

                selectedGacha--;

                //selectedGacha = selectedGacha % gachaCount;
                if (selectedGacha < 0)
                {
                    selectedGacha = maxGachaSetCount - 1;
                }

                for (int i = 0; i < titleImages.Count; i++)
                {
                    titleImages[i].enabled = false;
                }
                titleImages[selectedGacha].enabled = true;

                TextUpdate();
                AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.MECHANICAL_CLICK);
            }
        }
    }

    public void LoadMainMenu()
    {

        GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
    }


    public void SelectGacha()
    {
        //pass selectedGacha to player

        playerScript.Selected = selectedGacha;
        GameManager.Instance.ChangeScene(GameManager.Scene.GACHA);
    }

    private float GetDestinationRotation()
    {
        float toReturn = selectedGacha * rotationInterval;
        if (toReturn == 360 - rotationInterval && transform.eulerAngles.y <= rotationInterval)
            toReturn = -rotationInterval;
        if (toReturn == 0 && transform.eulerAngles.y >= 360 - rotationInterval)
            toReturn = 360;
        return toReturn;
    }

    
}