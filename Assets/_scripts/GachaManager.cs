using UnityEngine;
using System.Collections;

public class GachaManager : MonoBehaviour
{
    public Gacha myGacha;
    

    public void SetGachaData(Gacha gacha)
    {
        MeshFilter meshFilter = GetComponentInChildren<MeshFilter>();
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        myGacha = gacha;
        meshFilter.sharedMesh = myGacha.mesh;
        meshRenderer.material = myGacha.material;
    }

}
