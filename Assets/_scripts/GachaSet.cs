using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GachaSet : ScriptableObject
{
    public List<GameObject> collection;
    public new string name;
    public string description;

}
