using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour
{
    #region public properties
    public Text moneyTextField;
    public Text displayTextField;
    public int GachaSet = 0;
    public Rigidbody capsule;
    public GameObject seperator;
    GameObject instanceSep = null;
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

        player = playerObject.GetComponent<Player>();
        Debug.Assert(player != null, "player script was not found.");

        controller = GetComponent<Animator>();


        coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinDrag>();

        //audioSource = GetComponent<AudioSource>();
        //Debug.Assert(audioSource != null, "audio source component was not found.");

        Debug.Assert(moneyTextField != null, "Money text field not found, was it set in editor?");
        Debug.Assert(displayTextField != null, "Display text field not found, was it set in editor?");

        moneyTextField.text = player.TotalCoins.ToString();

        GachaSet = player.Selected;
        displayTextField.text = GameManager.Instance.GetGachaSet(GachaSet).name;

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

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            HandleClick(GameManager.Scene.MAIN);
        }
        RotateDial();
        
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
            player.AddGachaToList(GameManager.Instance.GetRandomGacha(GachaSet));
        }

    }
    #endregion

    public void RotateDial()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "gachamachine_dial"&& coin.isInSlot)
                {
                    Destroy(seperator);
                    seperator = null;
                    controller.SetTrigger("RotateDial");
                    AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.MECHANICAL_KACHUNK);

                  
                        Buy();
                        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.MONEY_CLINK);
                        
                        coin.isInSlot = false;


                    //WinGacha();
                }
            }
        }
    }
    public void WinGacha()
    {

   
        

            
        

        if (capsule.velocity.x ==0 && capsule.velocity.y ==0 && capsule.velocity.z ==0&&seperator==null)
        {
            capsule.transform.position = new Vector3(-8,0,0);
            capsule.transform.rotation = Quaternion.Euler(Vector3.up);
            Debug.Log("sadfkljhsdlfkj");
            capsule.useGravity = false;
        }
        

    }

    

}
