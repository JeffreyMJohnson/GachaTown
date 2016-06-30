using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BuyGacha : MonoBehaviour
{
    #region public properties   
    public int gachaSet = 0;
    public int prompt = 0;
    public float rotationSpeed = 10;
    public bool isGachaThere = false;
    public Text moneyTextField;
    public GameObject dialHolder;
    public Rigidbody capsule;
    public Material pink;
    public Material red;
    public Material green;
    public Material blue;
    public Material yellow;
    public Image displayText;
    public Sprite spooky;
    public Sprite sweets;
    public Sprite tropical;
    public Sprite city;
    public ParticleSystem coinPrompt;
    public ParticleSystem slotPrompt;
    public ParticleSystem dialPrompt;
    public GachaBall ball;
    #endregion

    #region private fields
    private Animator controller;
    private CoinDrag coin;
    #endregion

    #region unity lifecycle methods

    private void Start()
    {
        controller = GetComponent<Animator>();
        gachaSet = Player.Instance.Selected;

        coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinDrag>();
        Debug.Assert(moneyTextField != null, "Money text field not found, was it set in editor?");

        moneyTextField.text = Player.Instance.TotalCoins.ToString();

        GameObject frame = GameObject.FindGameObjectWithTag("Frame");
        MeshRenderer[] gachaTitles = GameObject.Find("GachaTitle").GetComponentsInChildren<MeshRenderer>(true);
        prompt = 0;
        switch (gachaSet) //0 = spooky, 1 = sweets, 2 = tropical, 3 = city
        {
            case 0:
                frame.GetComponent<Renderer>().material = blue;
                displayText.sprite = spooky;
                gachaTitles[0].enabled = true;
                SpriteRenderer[] spookySprites = gachaTitles[0].GetComponentsInChildren<SpriteRenderer>(true);
                foreach (SpriteRenderer spriterenderer in spookySprites)
                {
                    spriterenderer.enabled = true;
                }
                break;
            case 1:
                frame.GetComponent<Renderer>().material = green;
                displayText.sprite = sweets;
                gachaTitles[1].enabled = true;
                SpriteRenderer[] sweetsSprites = gachaTitles[1].GetComponentsInChildren<SpriteRenderer>(true);
                foreach (SpriteRenderer spriterenderer in sweetsSprites)
                {
                    spriterenderer.enabled = true;
                }
                break;
            case 2:
                frame.GetComponent<Renderer>().material = pink;
                displayText.sprite = tropical;
                gachaTitles[2].enabled = true;
                SpriteRenderer[] tropicalSprites = gachaTitles[2].GetComponentsInChildren<SpriteRenderer>(true);
                foreach (SpriteRenderer spriterenderer in tropicalSprites)
                {
                    spriterenderer.enabled = true;
                }
                break;
            case 3:
                frame.GetComponent<Renderer>().material = red;
                displayText.sprite = city;
                gachaTitles[3].enabled = true;
                SpriteRenderer[] citySprites = gachaTitles[3].GetComponentsInChildren<SpriteRenderer>(true);
                foreach (SpriteRenderer spriterenderer in citySprites)
                {
                    spriterenderer.enabled = true;
                }
                break;
            default:
                frame.GetComponent<Renderer>().material = yellow;
                break;
        }









        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            switch (button.name)
            {
                case "Main Menu Button":
                    button.onClick.AddListener(delegate { HandleClick(GameManager.Scene.MAIN); });
                    break;
                default:
                    break;
            }
        }

        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            HandleClick(GameManager.Scene.GACHACHOOSE);
        }
        RotateDial();
     

        switch (prompt) //0 is when coin needs to be put into slot, 1 is when coin is picked up, 2 is when coin is put down and anside the slot 3 is when player is meant to be waiting to open the gacha ball
        {
            case 0:
                if (!coinPrompt.isPlaying)
                {
                    coinPrompt.Play();
                    slotPrompt.Stop();
                    dialPrompt.Stop();
                }
                break;
            case 1:
                if (!slotPrompt.isPlaying)
                {
                    slotPrompt.Play();
                    coinPrompt.Stop();
                    dialPrompt.Stop();
                }
                break;
            case 2:
                if (!dialPrompt.isPlaying)
                {
                    dialPrompt.Play();
                    coinPrompt.Stop();
                    slotPrompt.Stop();
                }
                break;
            case 3:
                coinPrompt.Stop();
                slotPrompt.Stop();
                dialPrompt.Stop();
                break;
            default:
                coinPrompt.Stop();
                slotPrompt.Stop();
                dialPrompt.Stop();
                break;
        }


    }

    #endregion

    #region UI Handlers
    public void HandleClick(GameManager.Scene scene)
    {
        GameManager.Instance.ChangeScene(scene);
    }

    #endregion

    #region public API
    public void Buy()
    {
        //todo this magic number needs refactored out and money system implemented
        if (Player.Instance.TotalCoins >= 5)
        {
            Player.Instance.DeductCoins(5);
            moneyTextField.text = Player.Instance.TotalCoins.ToString();
            //todo remove this
            //player.AddGachaToList(GameManager.Instance.GetRandomGacha(gachaSet));
            Player.Instance.AddGachaToList(GachaManager.Instance.GetRandomGacha(gachaSet));
        }

    }
    #endregion

    public void RotateDial()
    {
        if (coin.isInSlot)
        {



            if (Input.GetMouseButton(0) && !isGachaThere)
            {



                RaycastHit hit;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {

                    // :( // I am so sorry for this
                    //four quadrants to make spinner rotate nicely on click
                    if (hit.collider.name == "LeftUpper")
                    {
                        dialHolder.transform.Rotate(new Vector3(0, 0, (Input.GetAxis("Mouse X") * rotationSpeed) + (Input.GetAxis("Mouse Y") * 5)));
                    }
                    if (hit.collider.name == "RightUpper")
                    {
                        dialHolder.transform.Rotate(new Vector3(0, 0, (Input.GetAxis("Mouse X") * rotationSpeed) + (-Input.GetAxis("Mouse Y") * 5)));
                    }
                    if (hit.collider.name == "LeftLower")
                    {
                        dialHolder.transform.Rotate(new Vector3(0, 0, (-Input.GetAxis("Mouse X") * rotationSpeed) + (Input.GetAxis("Mouse Y") * 5)));
                    }
                    if (hit.collider.name == "RightLower")
                    {
                        dialHolder.transform.Rotate(new Vector3(0, 0, (-Input.GetAxis("Mouse X") * rotationSpeed) + (-Input.GetAxis("Mouse Y") * 5)));
                    }




                }


                if (dialHolder.transform.rotation.z > .15f && dialHolder.transform.rotation.z < .4f || dialHolder.transform.rotation.z < -.15f && dialHolder.transform.rotation.z > -.4f)
                {
                    if (hit.collider.gameObject.name == "LeftUpper" || hit.collider.gameObject.name == "RightUpper" || hit.collider.gameObject.name == "LeftLower" || hit.collider.gameObject.name == "RightUpper")
                    {
                        //this is really dumb but due to constraints there will be two dials, one that will be able to rotate by the player, one that rotates after being instantiated inf ront of that one
                        controller.SetTrigger("RotateDial");
                        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.MECHANICAL_KACHUNK);
                        Buy();
                        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.MONEY_CLINK);
                        coin.isInSlot = false;
                        isGachaThere = true;
                        capsule.isKinematic = !capsule.isKinematic;
                        dialHolder.transform.rotation = Quaternion.Euler(0, -90, 0);
                        prompt = 3;
                    }
                }
            }
        }
    }
}





