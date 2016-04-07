using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GachaSet : ScriptableObject
{
    new string name;
    string description;
    List<Gacha> collection;

    public void AddGacha(Gacha toAdd)
    {
        collection.Add(toAdd);
    }

    public bool RemoveGacha(Gacha toRemove)
    {
        return collection.Remove(toRemove);
    }

    public Gacha GetGacha(int gachaIndex)
    {
        if (gachaIndex > collection.Count - 1)
            return new Gacha();
        return collection[gachaIndex];
    }

    public Gacha GetGacha(string name)
    {
        Gacha toReturn = new Gacha();

        foreach(Gacha gacha in collection)
        {
            if (gacha.name == name)
                toReturn = gacha;
        }

        return toReturn;
    }

    public Gacha GetRandomGacha()
    {
        int randomIndex = Random.Range(0, collection.Count);
        return collection[randomIndex];
    }

    public int GetGachaCount()
    {
        return collection.Count;
    }

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

}
