using UnityEngine;
using System.Collections;

public class GachaBall : MonoBehaviour
{
   public BuyGacha gachaMachine;
    Rigidbody capsule;
    Animator animator;
    bool canWin = false;
    // Use this for initialization
    void Start()
    {
        capsule = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        WinGacha();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "GachaWin")
        {
            canWin = !canWin;
        }
    }

    public void WinGacha()
    {







        if (capsule.velocity.x <.1&& capsule.velocity.x>-.1&&canWin)
        {
            capsule.transform.position = new Vector3(-8, 0, 0);
            capsule.transform.rotation = Quaternion.Euler(Vector3.up);           
            capsule.useGravity = false;
            capsule.isKinematic = true;
            animator.SetTrigger("OpenGacha");
            canWin = false;
        }


    }
}
