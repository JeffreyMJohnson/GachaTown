using UnityEngine;

[CreateAssetMenu()]
public class Gacha : ScriptableObject
{
    public GameObject basePrefab;
    public Mesh mesh;
    public Material material;
    public new string name;
}
