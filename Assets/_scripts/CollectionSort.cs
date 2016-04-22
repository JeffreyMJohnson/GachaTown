using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CollectionSort : MonoBehaviour
{
    #region public properties
    public Vector3 gachaOffset = new Vector3(-2, -3, 0);
    public Vector3 pageOffset = new Vector3(30, 0, 0);
    public Vector3 pageDestination;
    public Vector3 pageOrigin;
    public Vector2 displaySize = new Vector2(2, 3);
    public Material hiddenMaterial;
    #endregion

    #region private fields
    List<List<GameObject>> collectionPages = new List<List<GameObject>>();

    float scrollStart = 0;
    float scrollTime = 20;
    int currentPage = 0;
    const int MAX_GACHA_PER_PAGE = 9;

    private Player player;
    #endregion

    #region unity lifecycle methods
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        Debug.Assert(player != null, "no Player script in scene.");

        pageOrigin = transform.position;
        pageDestination = transform.position;

        //todo use accessor for this collection
        if (GameManager.instance.masterGachaSetList.Count == 0)
        {
            Debug.Log("setlist is empty");
        }

        InitCollectionPages();

        SetTitle();

        //todo get count of gacha sets
        //todo create page for each set
        //todo set pageCount to gacha set count

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
            GameManager.instance.ChangeScene(GameManager.Scene.MAIN);
        }

        if (scrollStart < scrollTime)
        {
            scrollStart++;
            transform.position = new Vector3(Mathf.Lerp(pageOrigin.x, pageDestination.x, scrollStart / scrollTime), 0);
        }

    }

    #endregion

    #region GUI
    void SetTitle()
    {
        Text title = GameObject.Find("PageTitle").GetComponent<Text>();
        title.text = GameManager.instance.masterGachaSetList[currentPage].name;
    }
    #endregion

    #region UI handlers
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
    #endregion


    void InitCollectionPages()
    {
        for (int i = 0; i < GameManager.instance.masterGachaSetList.Count; i++)
        {
            collectionPages.Add(new List<GameObject>());

            GachaSet set = GameManager.instance.masterGachaSetList[i];
            //case for when set contains less than Max count variable
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
                GachaID gachaID = new GachaID(i, j);
                GameObject gachaObject = GetGachaGameObject(gachaID);
                collectionPages[i].Add(gachaObject);
                gachaObject.transform.position = offset + (pageOffset * i);
               
                SetGachaMaterial(gachaObject, gachaID);
            }
        }
    }

    /// <summary>
    /// Sets the material of given gacha depending on if in players collection or not.
    /// </summary>
    /// <param name="gachaObject"></param>
    /// <param name="gachaID"></param>
    public void SetGachaMaterial(GameObject gachaObject, GachaID gachaID)
    {
        bool gachaInCollection = player.InCollection(gachaID);
        if (!gachaInCollection)
        {
            //if the model has animations implemented the mesh componenets change so here is some checking to get through this
            //when all implemented will need a cleaner way I imagine
            if (GameManager.instance.IsGachaAnimated(gachaObject))
            {
                SkinnedMeshRenderer mesh = gachaObject.GetComponentInChildren<SkinnedMeshRenderer>();
                Debug.Assert(mesh != null, "Skinned mesh renderer not found in model: " + gachaObject.name + "should the animator be disabled?");
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

    /// <summary>
    /// returns a GameObject instance from prefab matching GachaID.
    /// </summary>
    /// <param name="gachaID"></param>
    /// <returns></returns>
    GameObject GetGachaGameObject(GachaID gachaID)
    {
        Debug.Assert(gachaID.SetIndex < GameManager.instance.masterGachaSetList.Count);
        Debug.Assert(gachaID.GachaIndex < GameManager.instance.masterGachaSetList[gachaID.SetIndex].collection.Count);

        GameObject gachaPrefab = GameManager.instance.GetGachaPrefab(new GachaID(gachaID.SetIndex, gachaID.GachaIndex));
        GameObject newGacha = Instantiate<GameObject>(gachaPrefab);
        newGacha.transform.parent = transform;
        return newGacha;
    }


}
