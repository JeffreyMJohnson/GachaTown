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

    public GameObject[] currentPage;

    public GameObject[] nextPage;
    public GameObject[] previousPage;
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



            if (i <= pageSize - 1)
            {
                
                currentPage[i] = player.gachaCollection[i];
                currentPage[i].transform.position = gachaPositions[i].position;
               // previousPage[i] = player.gachaCollection[i];
            }

            
           

            //Transform model = gachaPositions[i].FindChild("Gacha");

            //model.GetComponent<MeshFilter>().sharedMesh = gacha.mesh;
            //model.GetComponent<MeshRenderer>().sharedMaterial = gacha.material;


        }
        //
        int index = 0;
        for (int j = pageSize; j < pageSize+pageSize; j++)
        {



            nextPage[index] = player.gachaCollection[j];
            nextPage[index].transform.position = gachaPositions[j].position;
            Debug.Log(player.gachaCollection[pageSize + j]);
            index += 1;

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
