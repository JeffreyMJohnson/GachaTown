using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GachaRotator : MonoBehaviour
{

    //all you have to do is slap a gacha machine object as a child of this one, make sure they're all in the same place

    public enum Menus { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE }
    public Text gachaDisplay;
    GameObject[] gachaMachines;
    Transform[] gachaTransforms;
    float rotationInterval = 0;
    public int selectedGacha = 0;
    int gachaCount = 0;
    float rotateStart;
    int rotateMax;
    Player playerScript;

	// Use this for initialization
	void Start ()
    {
        GameObject tPlayer = GameObject.FindGameObjectWithTag("Player");
        playerScript = tPlayer.GetComponent<Player>();
        Debug.Assert(playerScript != null, "Did not find Player script.");
        selectedGacha = playerScript.Selected;

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
    }
	
    void TextUpdate()
    {
        switch(selectedGacha)
        {
            case 0:
                gachaDisplay.text = "MACHINE NO. 0\nCOST 5";
                break;
            case 1:
                gachaDisplay.text = "MACHINE NO. 1\nCOST 5";
                break;
            case 2:
                gachaDisplay.text = "MACHINE NO. 2\nCOST 5";
                break;
            case 3:
                gachaDisplay.text = "MACHINE NO. 3\nCOST 5";
                break;
            case 4:
                gachaDisplay.text = "MACHINE NO. 4\nCOST 5";
                break;
            case 5:
                gachaDisplay.text = "MACHINE NO. 5\nCOST 5";
                break;
            case 6:
                gachaDisplay.text = "MACHINE NO. 6\nCOST 5";
                break;
            case 7:
                gachaDisplay.text = "MACHINE NO. 7\nCOST 5";
                break;
            default:
                gachaDisplay.text = "INVALID ENTRY";
                break;
        }
    }

    public void RotateLeft()
    {
        transform.Rotate(0, -rotationInterval, 0);

        selectedGacha--;
        if (selectedGacha == -1)
            selectedGacha = gachaCount - 1;
        selectedGacha = selectedGacha % gachaCount;

        TextUpdate();
    }

    public void RotateRight()
    {

        transform.Rotate(0, rotationInterval, 0);

        selectedGacha++;
        selectedGacha = selectedGacha % gachaCount;

        TextUpdate();
    }

    public void SelectGacha()
    {
        //pass selectedGacha to player
        playerScript.Selected = selectedGacha;
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)Menus.GACHA);

    }

    // Update is called once per frame
    void Update ()
    {

        //if (rotateStart == rotateMax)
        //{
        //    rotateStart += 0.05f;
        //}
        //float rotateY = Mathf.Lerp(0, rotationInterval, rotateStart / rotateMax);
        //transform.Rotate(0, rotateY, 0);


    }
}
