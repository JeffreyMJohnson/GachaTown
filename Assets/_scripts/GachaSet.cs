using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GachaSet : ScriptableObject
{
    public List<GameObject> collection;
    public string name;
    public string description;
}
