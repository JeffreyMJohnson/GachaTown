using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GachaRotator : MonoBehaviour
{

    //all you have to do is slap a gacha machine object as a child of this one, make sure they're all in the same place
    
    public Text gachaDisplay;
    public Text moneyDisplay;
    GameObject[] gachaMachines;
    Transform[] gachaTransforms;
    float rotationInterval = 0;
    public int selectedGacha = 0;
    int gachaCount = 0;
    public float rotateTime = 15; //in frames
    float rotateStart = 15;
    Player playerScript;

    private int maxGachaSetCount;

    //sounds have a chance of not working
    AudioSource sound;
    public AudioClip rotateGachaSound;
    public AudioClip buttonPressSound;
    
	void Start ()
    {
        GameObject tPlayer = GameObject.FindGameObjectWithTag("Player");
	    playerScript = tPlayer.GetComponent<Player>();
        sound = GetComponent<AudioSource>();
        Debug.Assert(playerScript != null, "Did not find Player script.");
        selectedGacha = playerScript.Selected;
        moneyDisplay.text = playerScript.TotalCoins.ToString();

        rotateStart = rotateTime;

        gachaMachines = new GameObject[transform.childCount];
        gachaTransforms = new Transform[transform.childCount];
        foreach( Transform child in transform)
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

	    maxGachaSetCount = GameManager.instance.masterGachaSetList.Count;
    }
	
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
            sound.PlayOneShot(rotateGachaSound);
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
            sound.PlayOneShot(rotateGachaSound);
        }
    }

    //I'm not being dumb, it's used by a button
    public void LoadMainMenu()
    {

        sound.PlayOneShot(buttonPressSound);
       
        GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
    }

    public void SelectGacha()
    {
        //pass selectedGacha to player
        sound.PlayOneShot(buttonPressSound);
        playerScript.Selected = selectedGacha;
        GameManager.instance.ChangeScene(GameManager.Menus.GACHA);
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

    void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadMainMenu();
        }
        if (rotateStart < rotateTime)
        {
            //bug add deltaTime for timing not frame count.  if you want frame count use an int
            rotateStart++;

            transform.Rotate(0, Mathf.Lerp(transform.eulerAngles.y, GetDestinationRotation(), rotateStart / rotateTime) - transform.eulerAngles.y, 0);

        }


    }
}
