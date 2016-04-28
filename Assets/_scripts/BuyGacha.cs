using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour
{
    #region public properties
    public Text moneyTextField;
    public Text displayTextField;
    public int GachaSet = 0;
    
    #endregion

    #region private fields
    Player player;
    GameObject gachaMachine;
    
    #endregion

    #region unity lifecycle methods
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(playerObject != null, "player gameObject not found, is GameManager instantiated via Main Menu scene?");

        player = playerObject.GetComponent<Player>();
        Debug.Assert(player != null, "player script was not found.");


        GameObject gachaObject = GameObject.FindGameObjectWithTag("GachaMachine");
        gachaMachine = gachaObject.GetComponent<GameObject>();
        

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

    
}
