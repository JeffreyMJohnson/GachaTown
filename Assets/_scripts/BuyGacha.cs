using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour
{
    #region public properties
    public Text moneyTextField;
    public Text displayTextField;
    public int gachaSet = 0;
    public Rigidbody capsule;
    public bool isGachaThere = false;
    public GameObject dialHolder;

    public Material pink;
    public Material red;
    public Material green;
    public Material blue;
    public Material yellow;
    #endregion

    #region private fields
    Player player;
    Animator controller;
    CoinDrag coin;

    #endregion
    
    #region unity lifecycle methods
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(playerObject != null, "player gameObject not found, is GameManager instantiated via Main Menu scene?");

        player = Player.Instance;

        controller = GetComponent<Animator>();


        coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinDrag>();

        Debug.Assert(moneyTextField != null, "Money text field not found, was it set in editor?");
        Debug.Assert(displayTextField != null, "Display text field not found, was it set in editor?");

        moneyTextField.text = player.TotalCoins.ToString();

        gachaSet = player.Selected;
        displayTextField.text = GameManager.Instance.GetGachaSet(gachaSet).name;


        GameObject frame = GameObject.FindGameObjectWithTag("Frame");
    

        switch (gachaSet)
        {
            case 0:
                frame.GetComponent<Renderer>().material = blue;
                break;
            case 1:
                frame.GetComponent<Renderer>().material = green;
                break;
            case 2:
                frame.GetComponent<Renderer>().material = pink;
                break;
            case 3:
                frame.GetComponent<Renderer>().material = red;
                break;
            case 4:
                frame.GetComponent<Renderer>().material = yellow;
                break;
        }






        
        

        //add onclick event for menu button
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            switch (button.name)
            {
                case "Main Menu Button":
                    button.onClick.AddListener(delegate { HandleClick(GameManager.Scene.MAIN); });
                    break;
                case "Buy Twenty Button":
                    button.onClick.AddListener(BuyLazy);
                    break;
                default:
                    break;
            }
        }

        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            HandleClick(GameManager.Scene.GACHACHOOSE);
        }
        RotateDial();
        Debug.Log(dialHolder.transform.rotation.z);
    }
    
    #endregion

    #region UI Handlers
    public void HandleClick(GameManager.Scene scene)
    {
        GameManager.Instance.ChangeScene(scene);
    }

    public void BuyLazy()
    {
        //GameManager.Instance.PlaySoundEffect(GameManager.Instance.fxBuyTwenty);
        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.MONEY_CHACHING);
        for (int i = 0; i < 20; i++)
        {
            Buy();
        }
    }
    #endregion

    #region public API
    public void Buy()
    {
        //todo this magic number needs refactored out and money system implemented
        if (player.TotalCoins >= 5)
        {
            player.DeductCoins(5);
            moneyTextField.text = player.TotalCoins.ToString();
            player.AddGachaToList(GameManager.Instance.GetRandomGacha(gachaSet));
        }

    }
    #endregion

    public void RotateDial()
    {
        if (Input.GetMouseButton(0) && !isGachaThere)
        {
           

            if (coin.isInSlot)
            {


                RaycastHit hit;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {

                    // :(
                    //four quadrants to make spinner rotate nicely on click
                    if (hit.collider.name == "LeftUpper")
                    {
                        dialHolder.transform.Rotate(new Vector3(0, 0, (Input.GetAxis("Mouse X") * 5) + (Input.GetAxis("Mouse Y") * 5)));
                    }
                    if (hit.collider.name == "RightUpper")
                    {
                        dialHolder.transform.Rotate(new Vector3(0, 0, (Input.GetAxis("Mouse X") * 5) + (-Input.GetAxis("Mouse Y") * 5)));
                    }
                    if (hit.collider.name == "LeftLower")
                    {
                        dialHolder.transform.Rotate(new Vector3(0, 0, (-Input.GetAxis("Mouse X") * 5) + (Input.GetAxis("Mouse Y") * 5)));
                    }
                    if (hit.collider.name == "RightLower")
                    {
                        dialHolder.transform.Rotate(new Vector3(0, 0, (-Input.GetAxis("Mouse X") * 5) + (-Input.GetAxis("Mouse Y") * 5)));
                    }




                }


                if (dialHolder.transform.rotation.z > .15f&& dialHolder.transform.rotation.z < .4f|| dialHolder.transform.rotation.z < -.15f&& dialHolder.transform.rotation.z > -.4f)
                {
                    if (hit.collider.gameObject.name == "LeftUpper" || hit.collider.gameObject.name == "RightUpper" || hit.collider.gameObject.name == "LeftLower" || hit.collider.gameObject.name == "RightUpper")
                    {
                        //this is really dumb but due to constraints there will be two dials, one that will be able to rotate by the player, one that rotates after being instantiated inf ront of that one
                        controller.SetTrigger("RotateDial");
                        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.MECHANICAL_KACHUNK);
                        Buy();
                        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.MONEY_CLINK);
                        coin.isInSlot = false;
                        capsule.isKinematic = !capsule.isKinematic;
                        isGachaThere = true;
                        dialHolder.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                }              
            }
        }
    }
    



}
