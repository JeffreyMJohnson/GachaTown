using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ShowCollection : MonoBehaviour
{
    public Player player;
    public Transform[] gachaPositions;
    public int pageSize = 9;
    public bool ShowGizmos = true;


    int currentPageNumber;

    public GameObject[] totalCollection;
    public GameObject[] currentPage;
    void Start()
    {
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
        for (int i = start; i < testCondition; i++)
        {
            currentPage[i - start] = player.gachaCollection[i];
        }

    }
    void SetGachasPosition(int page)
    {
        for (int i = 0; i < currentPage.Length; i++)
        {
            if (currentPage[i] != null)
            {
                currentPage[i].transform.position = gachaPositions[i].transform.position;
            }


        }

    }



    public void Previous()
    {
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
    }

    void OnDrawGizmos()
    {
        if (ShowGizmos)
        {
            for (int i = 0; i < gachaPositions.Length; i++)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(gachaPositions[i].position, Vector3.one);

            }
        }


    }
}
