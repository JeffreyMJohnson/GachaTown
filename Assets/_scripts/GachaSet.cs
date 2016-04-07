using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GachaSet : ScriptableObject
{
    public List<Gacha> collection;
    public string name;
    public string description;
}
