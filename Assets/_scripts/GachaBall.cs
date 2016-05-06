using UnityEngine;
using System.Collections;

public class GachaBall : MonoBehaviour
{
    public BuyGacha foo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == "GachaWin")
        {
            foo.WinGacha();
        }
    }
}
