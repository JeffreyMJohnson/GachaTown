using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinDrag : MonoBehaviour
{
    GameObject draggedCoin = null;
    //cached reference to child prefab for instantiating when dragged
    GameObject coinPrefab;
    BuyGacha machine;
    public bool isInSlot = false;
    
    void Start()
    {
        coinPrefab = transform.FindChild("Coin_1").gameObject;
        machine = FindObjectOfType<BuyGacha>();
        
    }

    void OnMouseDrag()
    {
        isInSlot = false;
        if (draggedCoin == null)
        {
            draggedCoin = Instantiate<GameObject>(coinPrefab);
        }
        //todo this will need to be changed to z axis when the model facing issue is corrected.
        Vector3 coinPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3.right * 3)-(Vector3.down*.5f) ;

        draggedCoin.transform.position = coinPosition;
        draggedCoin.transform.localEulerAngles = new Vector3(90, 0, 90);


    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0)&&!isInSlot)
        {
            

            //doing raycast here to find drop point. the coinslot collider doesn't belong to this object so the OnMouseUp function wont work here
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
           
            foreach (RaycastHit hit in hits)
            {
                
                //if dragged coin is null then we're just clicking on the button without dragging, it hits this anyways because ondragrelease doesn't exist
                if (hit.collider.gameObject.name == "gachamachine_coinslot" && draggedCoin != null)
                {
                   
                    draggedCoin.transform.rotation = Quaternion.Euler(90.0f, 356f, 0f);
                    draggedCoin.transform.position = new Vector3(-6.0f, 0.7f, -1.63f);

                    isInSlot = true;
                }
                
            }
            //either way destroy the coin clone when button released.

            if (!isInSlot)
            {
                Destroy(draggedCoin);
                draggedCoin = null;

            }


        }
        



    }

}
