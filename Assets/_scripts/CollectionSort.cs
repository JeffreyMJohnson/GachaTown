using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CollectionSort : MonoBehaviour
{
    #region public properties
    public Vector3 gachaOffset;// = new Vector3(-2, -3, 0);
    public Vector3 pageOffset;// = new Vector3(50, 0, 0);
    public Vector2 displaySize;// = new Vector2(2, 3);
    public Vector3 cameraStartPosition;//= new Vector3(6, 8.5, -10) 

    #endregion

    #region private fields

    private List<List<GameObject>> collectionPages = new List<List<GameObject>>();
    private Vector3 cameraDestination;
    private Vector3 cameraOrigin;
    private Vector3 pageDestination;
    private Vector3 pageOrigin;
    private Text title;
    private List<SpriteRenderer> titleCards = new List<SpriteRenderer>();
    private Ray ray;
    private RaycastHit hit;
    private float zoomLevelOrigin;
    private float zoomLevelDestination;
    private bool isZoomed = false;
    private float scrollStart;// = 0;
    private float scrollTime;// = 20;
    private int currentPage;// = 0;
    private float zoomStart;// = 0;
    private float zoomTime;// = 20;
    private const int MAX_GACHA_PER_PAGE = 9;   //DECIDED LIMIT FOR GACHA SETS, NO SET SHOULD HAVE MORE THAN 9
    private AudioSource buttonPress;

    private Camera collectionCamera;
    private Player player;
    #endregion

    #region unity lifecycle methods

    private void Start()
    {

        currentPage = 0;

        scrollStart = 0;
        scrollTime = 20;    //How many frames the lerp will last

        zoomStart = 0;
        zoomTime = 20;      //How many frames the lerp will last

        player = Player.Instance;
        buttonPress = GetComponent<AudioSource>();
        title = GameObject.Find("PageTitle").GetComponent<Text>();

        SpriteRenderer[] titleCardsToList = title.GetComponentsInChildren<SpriteRenderer>(true);
        //getting all of the spriterenderers for the title images so we can switch between them
        foreach (SpriteRenderer spriterenderer in titleCardsToList)
        {
            spriterenderer.enabled = false;
            titleCards.Add(spriterenderer);
        }

        collectionCamera = FindObjectOfType<Camera>();
        zoomLevelOrigin = collectionCamera.orthographicSize;
        zoomLevelDestination = zoomLevelOrigin;
        pageOrigin = transform.position;
        pageDestination = pageOrigin;
        cameraOrigin = cameraStartPosition;
        cameraDestination = cameraOrigin;

        //todo use accessor for this collection
        if (GameManager.Instance.masterGachaSetList.Count == 0)
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
                case "home":
                    button.onClick.AddListener(Home);
                    break;
                default:
                    break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Home();
        }

        

        //ray cast from screen position on left click release
        //if hits gacha, zoom in on it, load and enable description text
        //eventually enable rotate of the gacha
        if (Input.GetMouseButtonUp(0) && zoomStart == zoomTime) 
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) //the gacha was hit and we have the gacha
            {
                //this sometimes gives a null error when you attempt to click on creamy because it looks for a mesh in the immediate gameobject
                //also sometimes it just gives a null error
                if (player.InCollection(hit.transform.gameObject.GetComponent<Gacha>().ID))
                {
                    if (!isZoomed)//zoom in
                    {
                        //enable the description text here
                        isZoomed = true;
                        cameraOrigin = collectionCamera.transform.position;
                        cameraDestination = new Vector3(hit.transform.position.x, hit.transform.position.y + 1.5f, collectionCamera.transform.position.y);
                        zoomStart = 0;
                        zoomLevelOrigin = collectionCamera.orthographicSize;
                        zoomLevelDestination = 4.5f;
                    }
                    else //play animation
                    {
                        hit.transform.gameObject.GetComponent<Gacha>().PlayAnimation(Gacha.Animation.Special);
                    }
                }
            }//ELSE if mouse button up and raycast fails
                //save current mousex position and flip a bool
            //add ondrag
                //check if difference between saved mousex and current mousex is larger than 'value'
                    //if yes then call previous/next depending on positive/negative and save current mousex
            
        }

        if (scrollStart < scrollTime)
        {
            scrollStart++;
            transform.position = new Vector3(Mathf.Lerp(pageOrigin.x, pageDestination.x, scrollStart / scrollTime), 0);
        }

        if (zoomStart < zoomTime)
        {
            zoomStart++;
            collectionCamera.transform.position = new Vector3(Mathf.Lerp(cameraOrigin.x, cameraDestination.x, zoomStart / zoomTime),
                                                              Mathf.Lerp(cameraOrigin.y, cameraDestination.y, zoomStart / zoomTime),
                                                              collectionCamera.transform.position.z);
            collectionCamera.orthographicSize = Mathf.Lerp(zoomLevelOrigin, zoomLevelDestination, zoomStart / zoomTime);
        }
    }

    #endregion

    #region GUI

    private void SetTitle()
    {
        for (int i = 0; i < titleCards.Count; i++)
        {
            titleCards[i].enabled = false;
        }
        titleCards[currentPage].enabled = true;
        title.text = GameManager.Instance.masterGachaSetList[currentPage].name;
    }
    #endregion

    #region UI handlers
    public void Home()
    {
        if (isZoomed)
        {
            isZoomed = false;
            zoomStart = 0;
            zoomLevelDestination = 15;
            zoomLevelOrigin = collectionCamera.orthographicSize;
            cameraOrigin = collectionCamera.transform.position;
            cameraDestination = cameraStartPosition;

        }
        else
            GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
    }

    public void Previous()
    {
        if (currentPage != 0 && scrollStart == scrollTime && !isZoomed)
        {
            buttonPress.Play();
            currentPage--;
            SetTitle();
            scrollStart = 0;
            pageOrigin = transform.position;
            pageDestination = transform.position + pageOffset;
        }
        else if (currentPage == 0 && scrollStart == scrollTime && !isZoomed)
        {
            buttonPress.Play();
            currentPage = GameManager.Instance.masterGachaSetList.Count - 1;
            SetTitle();
            scrollStart = 0;
            pageOrigin = transform.position;
            float tCount = GameManager.Instance.masterGachaSetList.Count - 1;
            pageDestination = transform.position - new Vector3(pageOffset.x * tCount, pageOffset.y * tCount, pageOffset.z * tCount);
        }
    }
    
    public void Next()
    {
        if (currentPage < GameManager.Instance.masterGachaSetList.Count - 1 && scrollStart == scrollTime && !isZoomed)
        {
            buttonPress.Play();
            currentPage++;
            SetTitle();
            scrollStart = 0;
            pageOrigin = transform.position;
            pageDestination = transform.position - pageOffset;
        }
        else if (currentPage == GameManager.Instance.masterGachaSetList.Count - 1 && scrollStart == scrollTime && !isZoomed)
        {
            buttonPress.Play();
            currentPage = 0;
            SetTitle();
            scrollStart = 0;
            pageOrigin = transform.position;
            float tCount = GameManager.Instance.masterGachaSetList.Count - 1;
            pageDestination = transform.position + new Vector3(pageOffset.x * tCount, pageOffset.y * tCount, pageOffset.z * tCount);
        }
    }
    #endregion

    private void InitCollectionPages()
    {
        for (int i = 0; i < GameManager.Instance.masterGachaSetList.Count; i++)
        {
            collectionPages.Add(new List<GameObject>());

            GachaSet set = GameManager.Instance.masterGachaSetList[i];
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
                
                //instantiate the text objects here
                //fill the text objects with description text, changes if we own it or not
                //disable the description text
                

                SetGachaMaterial(gachaObject.GetComponent<Gacha>(), gachaID);
            }
        }
    }

    /// <summary>
    /// Sets the material of given gacha depending on if in players collection or not.
    /// </summary>
    /// <param name="gachaObject"></param>
    /// <param name="gachaID"></param>
    public bool SetGachaMaterial(Gacha gacha, GachaID gachaID)
    {
        bool gachaInCollection = player.InCollection(gachaID);
        if (!gachaInCollection)
        {
            //just changing the color with the api
            gacha.ChangeColor(new Color(0.2f, 0.2f, 0.2f));

            return gachaInCollection;
        }
        return gachaInCollection;
    }

    /// <summary>
    /// returns a GameObject Instance from prefab matching GachaID.
    /// </summary>
    /// <param name="gachaID"></param>
    /// <returns></returns>
    private GameObject GetGachaGameObject(GachaID gachaID)
    {
        Debug.Assert(gachaID.SetIndex < GameManager.Instance.masterGachaSetList.Count);
        Debug.Assert(gachaID.GachaIndex < GameManager.Instance.masterGachaSetList[gachaID.SetIndex].collection.Count);

        GameObject gachaPrefab = GameManager.Instance.GetGachaPrefab(new GachaID(gachaID.SetIndex, gachaID.GachaIndex));
        GameObject newGachaObject = Instantiate<GameObject>(gachaPrefab);
        newGachaObject.transform.parent = transform;
        Gacha newGacha = newGachaObject.GetComponent<Gacha>();//.ID = gachaID;
        newGacha.ID = gachaID;

        //CHECK HEIGHT/WIDTH HERE AND SCALE UP TRANSFORM
        Vector3 nSize = newGacha.Size;
        List<float> scale = new List<float>();

        scale.Add(5 / nSize.x);
        scale.Add(5 / nSize.y);
        //scale.Add(5 / nSize.z);

        float toScale = Mathf.Min(scale[0], scale[1]);

        Vector3 gachaScale = newGachaObject.transform.localScale;
        gachaScale.x *= toScale;
        gachaScale.y *= toScale;
        gachaScale.z *= toScale;

        newGachaObject.transform.localScale = gachaScale;

        //newGachaObject.transform.localScale = transform.localScale * Mathf.Min(scale[0], scale[1], scale[2]);


        return newGachaObject;
    }

}
