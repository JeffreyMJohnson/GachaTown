using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CollectionSort : MonoBehaviour
{

    public Vector3 gachaOffset = new Vector3(-2, -3, 0);
    public Vector3 pageOffset = new Vector3(30, 0, 0);
    public Vector3 pageDestination;
    public Vector3 pageOrigin;
    public Vector2 displaySize = new Vector2(2, 3);
    public Material hiddenMaterial;
    List<List<GameObject>> collectionPages = new List<List<GameObject>>();

    float scrollStart = 0;
    float scrollTime = 20;
    int currentPage = 0;
    int magicMaxGacha = 9;
	// Use this for initialization

    GameObject GetGachaGameObject(int setIndex, int gachaIndex)
    {
        if (gachaIndex > GameManager.instance.setList[setIndex].collection.Count - 1)
            gachaIndex = GameManager.instance.setList[setIndex].collection.Count - 1;
        Gacha gacha = GameManager.instance.setList[setIndex].collection[gachaIndex];
        GameObject newGacha = Instantiate<GameObject>(gacha.basePrefab);
        newGacha.transform.parent = transform;
        GachaManager gachaMan = newGacha.GetComponent<GachaManager>();
        gachaMan.SetGachaData(gacha);
        return newGacha;
    }

    void Start ()
    {
        pageOrigin = transform.position;
        pageDestination = transform.position;
        if (GameManager.instance.setList.Count == 0)
            Debug.Log("setlist is empty");

        for (int i = 0; i < GameManager.instance.setList.Count ; i++)
        {
            collectionPages.Add(new List<GameObject>());
            for (int j = 0; j < magicMaxGacha; j++)
            {
                collectionPages[i].Add(GetGachaGameObject(i, j));
                Vector3 offset = gachaOffset + new Vector3(displaySize.x * (int)(j / 3), displaySize.y * (j % 3));
                collectionPages[i][j].transform.position = offset + (pageOffset * i);
                if (!GameManager.instance.DoesPlayerHave(GameManager.instance.GetGachaName(i, j)))
                {
                    MeshRenderer material = collectionPages[i][j].GetComponentInChildren<MeshRenderer>();
                    material.material = hiddenMaterial;
                }
            }
        }

        SetTitle();



        //get count of gacha sets
        //create page for each set
        //set pageCount to gacha set count

        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            switch (button.name)
            {
                case "previous":
                    button.onClick.AddListener(Previous);
                    break;
                case "next":
                    button.onClick.AddListener(Next);
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
            GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
        }

        if (scrollStart < scrollTime)
        {
            scrollStart++;
            transform.position = new Vector3(Mathf.Lerp(pageOrigin.x, pageDestination.x, scrollStart / scrollTime),0);
        }

    }

    void SetTitle()
    {
        Text title = GameObject.Find("PageTitle").GetComponent<Text>();
        title.text = GameManager.instance.setList[currentPage].name;
    }

    public void Previous()
    {
        if (currentPage != 0 && scrollStart == scrollTime)
        {
            currentPage--;
            SetTitle();
            scrollStart = 0;
            pageOrigin = transform.position;
            pageDestination = transform.position + pageOffset;
        }
    }

    //next page
        //same as previous except don't be an idiot
    public void Next()
    {
        if (currentPage < GameManager.instance.setList.Count - 1 && scrollStart == scrollTime)
        {
            currentPage++;
            SetTitle();
            scrollStart = 0;
            pageOrigin = transform.position;
            pageDestination = transform.position - pageOffset;
        }
    }

}
