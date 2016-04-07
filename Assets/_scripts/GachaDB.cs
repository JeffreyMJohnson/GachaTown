using UnityEngine;
using System.Collections.Generic;

public class GachaDB
{

    public List<GachaSet> setList;

    public void init(List<GachaSet> toSet)
    {
        setList = toSet;
    }

    public void AddGachaSet(GachaSet toAdd)
    {
        setList.Add(toAdd);
    }

    public bool DeleteGachaSet(GachaSet toRemove)
    {
        return setList.Remove(toRemove);
    }

    public int GetGachaSetCount()
    {
        return setList.Count;
    }

    public GachaSet GetGachaSet(int setIndex)
    {
        if (setIndex > setList.Count - 1)
            return new GachaSet();
        return setList[setIndex];
    }

    public GachaSet GetGachaSet(string name)
    {
        GachaSet toReturn = new GachaSet();

        foreach(GachaSet set in setList)
        {
            if (set.name == name)
                toReturn = set;
        }

        return toReturn;
    }
}
