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
    #endregion

    #region unity lifecycle methods
    void Start()
    {
        //GameObject playerObject = Player.Instance.gameObject;

        playerScript = Player.Instance;
        


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
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
        }
        if (rotateStart < rotateTime)
        {
            //bug add deltaTime for timing not frame count.  if you want frame count use an int
            rotateStart++;

            transform.Rotate(0, Mathf.Lerp(transform.eulerAngles.y, GetDestinationRotation(), (float)rotateStart / (float)rotateTime) - transform.eulerAngles.y, 0);
        }
    }
    #endregion

    void TextUpdate()
    {
        gachaDisplay.text = "MACHINE NO. " + (selectedGacha + 1) + "\nCOST 5\n" + GameManager.Instance.masterGachaSetList[selectedGacha].name;
    }

    /// <summary>
    /// decrease gacha set index
    /// </summary>
    public void RotateLeft()
    {
        if (rotateStart == rotateTime)
        {
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

    /// <summary>
    /// decrease gacha set index
    /// </summary>
    public void RotateRight()
    {
        //bug this needs to be changed float equality is not done this way
        if (rotateStart == rotateTime)
        {
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
    public void LoadMainMenu()
    {

        GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
    }

    //I'm not being dumb, it's used by a button

    public void SelectGacha()
    {
        //pass selectedGacha to player

        playerScript.Selected = selectedGacha;
        GameManager.Instance.ChangeScene(GameManager.Scene.GACHA);
    }
    float GetDestinationRotation()
    {
        float toReturn = selectedGacha * rotationInterval;
        if (toReturn == 360 - rotationInterval && transform.eulerAngles.y <= rotationInterval)
            toReturn = -rotationInterval;
        if (toReturn == 0 && transform.eulerAngles.y >= 360 - rotationInterval)
            toReturn = 360;
        return toReturn;
    }
}