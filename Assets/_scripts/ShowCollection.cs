using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ShowCollection : MonoBehaviour
{
    public Player player;
    public Transform[] gachaPositions;
    GameObject gameManager;
    GameObject collection;
    public int pageSize = 9;
    int currentPageNumber;
    //public GameObject[] currentPage;

    //public GameObject[] nextPage;
    //public GameObject[] previousPage;
    public GameObject[] totalCollection;
    public GameObject[] currentPage;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        collection = GameObject.Find("Collection");
        player = FindObjectOfType<Player>();
        currentPageNumber = 0;
        currentPage = new GameObject[pageSize];
        SetCollection();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
        }
    }

    private void SetCollection()
    {
     
      SetCurrentPage(currentPageNumber);
      SetGachasPosition(currentPageNumber);
        
    }

   public void SetCurrentPage(int page)
        {
        int start = pageSize * page;
        int testCondition = start + pageSize;
        if (player.gachaCollection.Count < testCondition)
        {
            testCondition = player.gachaCollection.Count;
        }
        for (int i = start; i < testCondition;i++)
        {   
                currentPage[i - start] = player.gachaCollection[i];                        
        }
        //return currentPage;
            
    }
    void SetGachasPosition(int page)
    {
        for (int i = 0; i < currentPage.Length; i++)
        {
            if (currentPage[i]!=null)
            {
                currentPage[i].transform.position = gachaPositions[i].transform.position;
            }
            

        }

    }



    public void Previous()
    {
        //collection.transform.position = Vector3.Lerp(collection.transform.position,collection.transform.position + (Vector3.right*5),Time.deltaTime);
        //mPrev = true;
        //for (int i = 0; i < page.nextPage.Length; i++)
        //{
        //    page.currentPage = page.nextPage;
        //}
        //if (pageNumber >= 0)
        //{
        //    collection.transform.Translate(Vector3.right * 6);
        //    for (int i = 0; i < page.currentPage.Length; i++)
        //    {

        //        page.currentPage[i] = page.previousPage[i];

        //    }
        //    Debug.Log("previous");
        //}

        if (currentPageNumber > 0)
        {
            currentPageNumber -= 1;
            SetCurrentPage(currentPageNumber);
        }


    }
    public void Next()
    {
        currentPageNumber += 1;
        SetCurrentPage(currentPageNumber);
        //mNext = true;
        //collection.transform.Translate(Vector3.left * 6);



        //for (int i = 0; i < page.currentPage.Length; i++)
        //{

        //    page.previousPage[i] = page.currentPage[i];

        //}

        //for (int i = 0; i < page.currentPage.Length; i++)
        //{

        //    page.currentPage[i] = page.nextPage[i];

        //}

        Debug.Log("next");
    }

    void OnDrawGizmos()
    {
        for(int i = 0; i < gachaPositions.Length; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(gachaPositions[i].position, Vector3.one);
            
        }
        
    }
}
