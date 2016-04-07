﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinDrag : MonoBehaviour
{
    GameObject draggedCoin = null;
    //cached reference to child prefab for instantiating when dragged
    GameObject coinPrefab;
    BuyGacha machine;
    AudioSource coinDrop;
    

    void Start()
    {
        coinPrefab = transform.FindChild("Coin_1").gameObject;
        machine = FindObjectOfType<BuyGacha>();
        coinDrop = GetComponent<AudioSource>();
    }

    void OnMouseDrag()
    {
         if (draggedCoin == null)
        {
            draggedCoin = Instantiate<GameObject>(coinPrefab);
        }
        //this will need to be changed to z axis when the model facing issue is corrected.
        Vector3 coinPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.right * 3;
        draggedCoin.transform.position = coinPosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //doing raycast here to find drop point. the coinslot collider doesn't belong to this object so the OnMouseUp function wont work here
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                //if dragged coin is null then we're just clicking on the button without dragging, it hits this anyways because ondragrelease doesn't exist
                if (hit.collider.gameObject.name == "coinslot" && draggedCoin != null)
                {
                    machine.Buy();
                    coinDrop.Play();
                }
            }
            //either way destroy the coin clone when button released.
            Destroy(draggedCoin);
            draggedCoin = null;
        }
    }

}
