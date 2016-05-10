using UnityEngine;
using System.Collections;

public class GachaBall : MonoBehaviour
{
   public BuyGacha gachaMachine;
    Rigidbody capsule;
    Animator animator;
    bool canWin = false;
    float currentTime = 0f;
    float timeToMove = 2f;
    Vector3 startPos;
    Vector3 endPos = new Vector3(-8,0,0);
    Vector3 startRotation;
    Vector3 endRotation;
    Player gacha;
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

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.gameObject.name == "GachaWin")
        {
            if (capsule.velocity.x < .1 && capsule.velocity.x > -.1 && !canWin)
            {
                canWin = true;
                startPos = capsule.transform.position;
                startRotation = capsule.transform.rotation.eulerAngles;
                endRotation.Set(0, -90, 0);
            }

        }
    }

    public void WinGacha()
    {
        






        if (canWin)
        {
            
            
            if (currentTime <= timeToMove)
            {
                currentTime += Time.deltaTime;
                capsule.transform.position = Vector3.Lerp(startPos,endPos, currentTime / timeToMove);
                //capsule.transform.Rotate(capsule.transform.rotation.eulerAngles - Vector3.Lerp(startRotation, endRotation, currentTime / timeToMove)  );
                capsule.transform.eulerAngles = new Vector3
                   (Mathf.Lerp(startRotation.x, endRotation.x, currentTime / timeToMove),
                    Mathf.Lerp(startRotation.y, endRotation.y, currentTime / timeToMove),
                    Mathf.Lerp(startRotation.z, endRotation.z, currentTime / timeToMove));
            }

            if (currentTime > timeToMove)
            {
                canWin = false;
                animator.SetTrigger("OpenGacha");
                GameObject newGacha = GameManager.Instance.GetGachaPrefab(gacha.gachaCollection[gacha.gachaCollection.Count - 1]);
                newGacha.transform.position = endPos;

              
            }


            //capsule.transform.rotation = Quaternion.Euler(Vector3.forward);    

            capsule.isKinematic = true;

            //instantiate a gacha prefab to show what you got

       
        }


    }
}
