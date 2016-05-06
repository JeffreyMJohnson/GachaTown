﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CollectionSort : MonoBehaviour
{
    #region public properties
    public Vector3 gachaOffset;// = new Vector3(-2, -3, 0);
    public Vector3 pageOffset;// = new Vector3(50, 0, 0);
    public Vector2 displaySize;// = new Vector2(2, 3);
    public Material hiddenMaterial;
    public Vector3 cameraStartPosition;//= new Vector3(6, 8.5, -10) 

    #endregion

    #region private fields
    List<List<GameObject>> collectionPages = new List<List<GameObject>>();
    Vector3 cameraDestination;
    Vector3 cameraOrigin;
    Vector3 pageDestination;
    Vector3 pageOrigin;
    Ray ray;
    RaycastHit hit;
    float zoomLevelOrigin;
    float zoomLevelDestination;
    float scrollStart = 0;
    float scrollTime = 20;
    float zoomStart = 0;
    float zoomTime = 20;
    int currentPage = 0;
    const int MAX_GACHA_PER_PAGE = 9;
    AudioSource buttonPress;
    bool isZoomed = false;

    Camera collectionCamera;
    private Player player;
    #endregion

    #region unity lifecycle methods
    void Start()
    {
        player = Player.Instance;
        buttonPress = GetComponent<AudioSource>();

        zoomLevelOrigin = 15;
        zoomLevelDestination = zoomLevelOrigin;
        pageOrigin = transform.position;
        pageDestination = pageOrigin;
        cameraOrigin = cameraStartPosition;
        cameraDestination = cameraOrigin;

        collectionCamera = FindObjectOfType<Camera>();

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
                default:
                    break;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
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


        //ray cast from screen position on left click release
        //if hits gacha, zoom in on it, load and enable description text
        //eventually enable rotate of the gacha
        if (Input.GetMouseButtonUp(0) && zoomStart == zoomTime) 
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && player.InCollection(hit.transform.gameObject.GetComponent<Gacha>().ID)) //the gacha was hit and we have the gacha
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
    void SetTitle()
    {
        Text title = GameObject.Find("PageTitle").GetComponent<Text>();
        title.text = GameManager.Instance.masterGachaSetList[currentPage].name;
    }
    #endregion

    #region UI handlers
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
    }
    #endregion


    void InitCollectionPages()
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

                SphereCollider gachaSphereCollider = gachaObject.AddComponent<SphereCollider>(); ;
                gachaSphereCollider.center = new Vector3(0, 2, 0);
                gachaSphereCollider.radius = 2.5f;

                SetGachaMaterial(gachaObject, gachaID);
            }
        }
    }

    /// <summary>
    /// Sets the material of given gacha depending on if in players collection or not.
    /// </summary>
    /// <param name="gachaObject"></param>
    /// <param name="gachaID"></param>
    public bool SetGachaMaterial(GameObject gachaObject, GachaID gachaID)
    {
        bool gachaInCollection = player.InCollection(gachaID);
        if (!gachaInCollection)
        {
            //if the model has animations implemented the mesh componenets change so here is some checking to get through this
            //when all implemented will need a cleaner way I imagine
            if (GameManager.Instance.IsGachaAnimated(gachaObject))
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
            return gachaInCollection;
        }
        return gachaInCollection;
    }

    /// <summary>
    /// returns a GameObject Instance from prefab matching GachaID.
    /// </summary>
    /// <param name="gachaID"></param>
    /// <returns></returns>
    GameObject GetGachaGameObject(GachaID gachaID)
    {
        Debug.Assert(gachaID.SetIndex < GameManager.Instance.masterGachaSetList.Count);
        Debug.Assert(gachaID.GachaIndex < GameManager.Instance.masterGachaSetList[gachaID.SetIndex].collection.Count);

        GameObject gachaPrefab = GameManager.Instance.GetGachaPrefab(new GachaID(gachaID.SetIndex, gachaID.GachaIndex));
        GameObject newGacha = Instantiate<GameObject>(gachaPrefab);
        newGacha.transform.parent = transform;
        newGacha.GetComponent<Gacha>().ID = gachaID;
        return newGacha;
    }


}
