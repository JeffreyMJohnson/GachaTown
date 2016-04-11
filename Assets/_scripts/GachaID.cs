using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct GachaID : IEquatable<GachaID>
{
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

    private int _setIndex, _gachaIndex;

    public GachaID(int a_setIndex, int a_gachaIndex)
    {
        _setIndex = a_setIndex;
        _gachaIndex = a_gachaIndex;
    }

    public bool Equals(GachaID other)
    {
        return this == other;
    }

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


}
