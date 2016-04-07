using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour
{


    public Text moneyTextField;
    public Text displayTextField;
    public int GachaSet = 0;

    Player localPlayer;
    AudioSource buttonSound;
    void Start()
    {
        GameObject tPlayer = GameObject.FindGameObjectWithTag("Player");
        localPlayer = tPlayer.GetComponent<Player>();
        buttonSound = GetComponent<AudioSource>();
        moneyTextField.text = localPlayer.TotalCoins.ToString();
        displayTextField.text = GameManager.instance.GetGachaSet(GachaSet).name;

        //add onclick event for menu button
        Button[] buttons = FindObjectsOfType<Button>(); //can't add more than one button in this scene
        foreach (Button button in buttons)
        {
            if (button.name == "Main Menu Button")
            {
                
                button.onClick.AddListener(delegate { HandleClick(GameManager.Menus.MAIN); });
            }
        }
    }
    
    public void HandleClick(GameManager.Menus scene)
    {

        buttonSound.Play();//sometimes doesn't work if you click multiple times
        GameManager.instance.ChangeScene(scene);
    }

    

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            HandleClick(GameManager.Menus.MAIN);
        }
    }

    public void Buy()
    {
        if (localPlayer.TotalCoins >= 5)
        {
            localPlayer.TotalCoins -= 5;
            moneyTextField.text = localPlayer.TotalCoins.ToString();
            localPlayer.AddGachaToList(GameManager.instance.GetRandomGacha(GachaSet));
        }

    }

    
}
