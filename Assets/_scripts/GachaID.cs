using System;
using UnityEngine;

[System.Serializable]
public struct GachaID : IEquatable<GachaID>
{
    #region constructors
    public GachaID(int a_setIndex, int a_gachaIndex)
    {
        _setIndex = a_setIndex;
        _gachaIndex = a_gachaIndex;
    }
    #endregion

    #region public properties
    public int SetIndex
    {
        get { return _setIndex; }
        private set { _setIndex = value; }
    }
    
    public int GachaIndex
    {
        get { return _gachaIndex; }
        private set { _gachaIndex = value; }
    }
    #endregion

    #region private fields
    [SerializeField]
    private int _setIndex;
    [SerializeField]
    private int _gachaIndex;
    #endregion

    #region IEquatable<GachaID> implementation
    public bool Equals(GachaID other)
    {
        return this == other;
    }
    #endregion

    #region equality and implementation
    public override bool Equals(object obj)
    {
        return obj is GachaID && this == (GachaID)obj;
    }

    public override int GetHashCode()
    {
        return SetIndex ^ GachaIndex;
    }

    public static bool operator ==(GachaID x, GachaID y)
    {
        return (x.SetIndex == y.SetIndex) && (x.GachaIndex == y.GachaIndex);
    }

    public static bool operator !=(GachaID x, GachaID y)
    {
        return !(x == y);
    }
    #endregion
}
