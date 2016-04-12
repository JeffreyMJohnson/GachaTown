using UnityEngine;
using System.Collections;

public class Gacha : MonoBehaviour
{
    public bool IsAnimated = false;

    #region unity lifecycle methods

    void Start()
    {
        Animator anim = GetComponent<Animator>();
        Debug.Assert(anim != null, "No animator component found.");
        IsAnimated = anim.enabled;
        Debug.Log(name + " is animated:" + IsAnimated);
    }


#endregion
}
