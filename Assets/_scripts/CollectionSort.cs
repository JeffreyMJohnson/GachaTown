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
    const int MAX_GACHA_PER_PAGE = 9;

    private Player player;

    // Use this for initialization

    /// <summary>
    /// returns a GameObject instance from prefab matching given set and gacha index.
    /// </summary>
    /// <param name="setIndex"></param>
    /// <param name="gachaIndex"></param>
    /// <returns></returns>
    GameObject GetGachaGameObject(int setIndex, int gachaIndex)
    {
        //todo review this with Tyler
        /*
        if (gachaIndex > GameManager.instance.setList[setIndex].collection.Count - 1)
            gachaIndex = GameManager.instance.setList[setIndex].collection.Count - 1;
            */
        Debug.Assert(setIndex < GameManager.instance.masterGachaSetList.Count);
        Debug.Assert(gachaIndex < GameManager.instance.masterGachaSetList[setIndex].collection.Count);


        GameObject gachaPrefab = GameManager.instance.GetGachaPrefab(setIndex, gachaIndex);
        GameObject newGacha = Instantiate<GameObject>(gachaPrefab);
        newGacha.transform.parent = transform;
        //GachaManager gachaMan = newGacha.GetComponent<GachaManager>();
        // gachaMan.SetGachaData(gacha);
        return newGacha;
    }

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        Debug.Assert(player != null, "no Player script in scene.");

        pageOrigin = transform.position;
        pageDestination = transform.position;
        if (GameManager.instance.masterGachaSetList.Count == 0)
            Debug.Log("setlist is empty");

        for (int i = 0; i < GameManager.instance.masterGachaSetList.Count; i++)
        {
            collectionPages.Add(new List<GameObject>());

            //todo need to check if max is greater than count of set
            GachaSet set = GameManager.instance.masterGachaSetList[i];
            int currentPageCount = 0;
            if (MAX_GACHA_PER_PAGE > set.collection.Count)
            {
                currentPageCount = set.collection.Count;
            }
            else
            {
                currentPageCount = MAX_GACHA_PER_PAGE;
            }

            for (int j = 0; j < currentPageCount; j++)
            {
                Vector3 offset = gachaOffset + new Vector3(displaySize.x * (int)(j / 3), displaySize.y * (j % 3));
                GameObject gachaObject = GetGachaGameObject(i, j);
                collectionPages[i].Add(gachaObject);
                gachaObject.transform.position = offset + (pageOffset * i);
                bool gachaInCollection = player.InCollection(new GachaID(i, j));

                if (!gachaInCollection)
                {
                    //if the model has animations implemented the mesh componenets change so here is some checking to get through this
                    //when all implemented will need a cleaner way I imagine
                    if (GameManager.instance.IsGachaAnimated(gachaObject))
                    {
                        SkinnedMeshRenderer mesh = gachaObject.GetComponentInChildren<SkinnedMeshRenderer>();
                        Debug.Assert(mesh != null, "Skinned mesh renderer not found in model: " + gachaObject.name);
                        mesh.material = hiddenMaterial;
                    }
                    else
                    {
                        MeshRenderer mesh = gachaObject.GetComponentInChildren<MeshRenderer>();
                        Debug.Assert(mesh != null, "Mesh component not found in model: " + gachaObject.name);
                        mesh.material = hiddenMaterial;
                    }


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
            transform.position = new Vector3(Mathf.Lerp(pageOrigin.x, pageDestination.x, scrollStart / scrollTime), 0);
        }

    }

    void SetTitle()
    {
        Text title = GameObject.Find("PageTitle").GetComponent<Text>();
        title.text = GameManager.instance.masterGachaSetList[currentPage].name;
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
        if (currentPage < GameManager.instance.masterGachaSetList.Count - 1 && scrollStart == scrollTime)
        {
            currentPage++;
            SetTitle();
            scrollStart = 0;
            pageOrigin = transform.position;
            pageDestination = transform.position - pageOffset;
        }
    }

}
