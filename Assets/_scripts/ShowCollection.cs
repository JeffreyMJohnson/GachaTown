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

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        collection = GameObject.Find("Collection");
        player = FindObjectOfType<Player>();
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
       for (int i = 0; i < player.gachaCollection.Count; i++)
        {
            GameObject gacha = player.gachaCollection[i];
            gacha.transform.position = gachaPositions[i].position;
            //Transform model = gachaPositions[i].FindChild("Gacha");
            
            //model.GetComponent<MeshFilter>().sharedMesh = gacha.mesh;
            //model.GetComponent<MeshRenderer>().sharedMaterial = gacha.material;
            

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
