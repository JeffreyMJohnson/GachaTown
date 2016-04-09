using UnityEngine;
using System.Collections;

public class GachaManager : MonoBehaviour
{
    public Gacha myGacha;
    

    public void SetGachaData(Gacha gacha)
    {
        MeshFilter meshFilter = GetComponentInChildren<MeshFilter>();
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        Animator anim = GetComponentInChildren<Animator>();
        myGacha = gacha;
        meshFilter.sharedMesh = myGacha.mesh;
        meshRenderer.material = myGacha.material;
        name = gacha.name;
        anim.runtimeAnimatorController = gacha.animControl;
    }

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.name == "Lemur")
        {
            //todo animate here
            Debug.Log("Animate me!");
        }

    }



}
