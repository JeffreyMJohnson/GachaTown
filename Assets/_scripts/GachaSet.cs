using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GachaSet : ScriptableObject
{
    public List<Gacha> collection;
    public new string name;
    public string description;

}
