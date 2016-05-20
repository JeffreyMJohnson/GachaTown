using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ShowCollection : MonoBehaviour
{
    #region public properties
    public Player player;
    public Vector3 gachaPosition;
    public int pageSize = 9;
    public GameObject[] totalCollection;
    public GameObject[] currentPage;
    public bool ShowGizmos = true;
    #endregion

    #region private fields

    private int currentPageNumber;
    #endregion

    #region unity lifecycle methods

    private void Start()
    {
        player = Player.Instance;
        currentPageNumber = 0;
        currentPage = new GameObject[pageSize];
        SetCollection(currentPageNumber);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
        }
    }

    private void OnDrawGizmos()
    {
        //fix this shit
        //if (ShowGizmos)
        //{
        //    for (int i = 0; i < gachaPositions.Length; i++)
        //    {
        //        Gizmos.color = Color.green;
        //        Gizmos.DrawWireCube(gachaPositions[i].position, Vector3.one);

        //    }
        //}


    }
    #endregion

    #region Public API
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
            GachaID gachaID = player.gachaCollection[i];
            currentPage[i - start] = GameManager.Instance.GetGachaPrefab(gachaID);
        }

    }

    public void Previous()
    {
        if (currentPageNumber > 0)
        {
            ClearGachaSpot();
            currentPageNumber -= 1;
            SetCollection(currentPageNumber);
        }
    }

    public void Next()
    {
        if (currentPageNumber * pageSize < player.gachaCollection.Count - pageSize)
        {
            ClearGachaSpot();
            currentPageNumber += 1;
        }
        Debug.Log("next");
    }

    public void ClearGachaSpot()
    {
        for (int i = 0; i < currentPage.Length; i++)
        {
            if (currentPage[i] == null)
            {
                continue;
            }

            //currentPage[i].transform.Translate(0, 100, 0);

            //currentPage[i] = null;
            Destroy(currentPage[i]);

        }
    }
    #endregion

    private void SetCollection(int page)
    {
        SetCurrentPage(page);
        SetGachasPosition(page);

    }


    private void SetGachasPosition(int page)
    {
        for (int i = 0; i < currentPage.Length; i++)
        {
            if (currentPage[i] != null)
            {
                //fis this shit
                //currentPage[i].transform.position = gachaPositions[i].transform.position;
            }


        }

    }






}
