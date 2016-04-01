using UnityEngine;using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ShowCollection : MonoBehaviour
{
    public Player player;
    public Transform[] gachaPositions;
    GameObject gameManager;
    GameObject collection;
    public int pageSize = 9;

    //public GameObject[] currentPage;

    //public GameObject[] nextPage;
    //public GameObject[] previousPage;
    public GameObject[] totalCollection;
    public GameObject[] testPage;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        collection = GameObject.Find("Collection");
        player = FindObjectOfType<Player>();
        SetCollection();
    }

    private void SetCollection()
    {
     
       for (int i = 0; i < player.gachaCollection.Count; i++)
        {
            //testPage.Length = player.gachaCollection.Count;



            totalCollection[i] = player.gachaCollection[i];
            totalCollection[i].transform.position = gachaPositions[i].position;
               // previousPage[i] = player.gachaCollection[i];
            

            
           

            //Transform model = gachaPositions[i].FindChild("Gacha");

            //model.GetComponent<MeshFilter>().sharedMesh = gacha.mesh;
            //model.GetComponent<MeshRenderer>().sharedMaterial = gacha.material;


        }
        //
        //int index = 0;
        //for (int j = pageSize; j < pageSize+pageSize; j++)
        //{



        //    nextPage[index] = player.gachaCollection[j];
        //    nextPage[index].transform.position = gachaPositions[j].position;
        //    Debug.Log(player.gachaCollection[pageSize + j]);
        //    index += 1;

        //}
    }

   public void GetGacha(int page)
    {


        for (int i = page*pageSize; i < ((page*pageSize)+pageSize);i++)
        {
            if (player.gachaCollection[i]!=null)
            {
                testPage[i - (page * pageSize)] = player.gachaCollection[i];
            }
            
        }
    

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
