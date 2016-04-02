using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[Serializable]
class GachaCollection
{
    /// <summary>
    /// Add Gacha to collection
    /// </summary>
    /// <param name="newGacha">Gacha to add</param>
    public void AddGacha(Gacha newGacha)
    {
        if (_collection == null)
        {
            _collection = new List<Gacha>();
        }
        _collection.Add(newGacha);
    }

    public void Clear()
    {
        _collection.Clear();
    }

    public void Load()
    {
        foreach (Gacha gacha in _collection)
        {
            
        }
    }

    #region private
    [UnityEngine.SerializeField]
    private List<Gacha> _collection;

    #endregion
}
