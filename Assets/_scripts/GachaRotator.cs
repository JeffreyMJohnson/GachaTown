using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GachaRotator : MonoBehaviour
{

    //all you have to do is slap a gacha machine object as a child of this one, make sure they're all in the same place
    #region public properties
    public Text gachaDisplay;
    public Text moneyDisplay;
    public int selectedGacha = 0;
    public float rotateTime = 15; //in frames
    #endregion

    #region private fields
    private int maxGachaSetCount;
    private GameObject[] gachaMachines;
    private Transform[] gachaTransforms;
    private float rotationInterval = 0;
    private float rotateStart = 15;
    private Player playerScript;
    private int gachaCount = 0;
    #endregion

    #region unity lifecycle methods
void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(playerObject != null, "player gameObject nout found.");

        playerScript = playerObject.GetComponent<Player>();
        Debug.Assert(playerScript != null, "Did not find Player script.");


        //audioSource = GetComponent<AudioSource>();
        //Debug.Assert(audioSource != null, "audio source component not found.");

        selectedGacha = playerScript.Selected;
        Debug.Assert(moneyDisplay != null, "Money text component not found, set in editor?");
        moneyDisplay.text = playerScript.TotalCoins.ToString();

        Debug.Assert(gachaDisplay != null, "gacha display text component not found, set in editor ?");

    

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

        for (int i = 0; i < playerScript.Selected; i++)
        {
            transform.Rotate(0, rotationInterval, 0);
        }
        TextUpdate();

        maxGachaSetCount = GameManager.Instance.masterGachaSetList.Count;
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

            transform.Rotate(0, Mathf.Lerp(transform.eulerAngles.y, GetDestinationRotation(), rotateStart / rotateTime) - transform.eulerAngles.y, 0);

        }


    }
    #endregion




    void TextUpdate()
    {
        gachaDisplay.text = "MACHINE NO. " + selectedGacha + "\nCOST 5";
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

            TextUpdate();
            AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.ROTATE);
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


            TextUpdate();
            AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.ROTATE);
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
