using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GachaSet : ScriptableObject
{
    public GachaManager.Set id;
    public new string name;
    public string description;
    public List<GameObject> collection;

}
