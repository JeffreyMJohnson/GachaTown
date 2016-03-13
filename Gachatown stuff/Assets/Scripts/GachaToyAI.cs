using UnityEngine;
using System.Collections;

public class GachaToyAI : MonoBehaviour
{
    Transform tr;
    public Transform target;
    public bool isSeeking;
    public bool isWandering;
    float speed = .02f;
    Vector3 npcPos;
    Vector3 targetPos;

    Vector3 kung;
    Vector3 fu;

    Vector3 wanderDir;
    void Start()
    {
        tr = GetComponent<Transform>();
        //fu = transform.rotation.eulerAngles;
        //fu.x = 0;
        //fu.z = 0;
        isWandering = false;
        isSeeking = true;

    }
    void Update()
    {
        
        
        
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            isWandering = false;
            isSeeking = true;
        }
        if (Input.GetKeyDown("s"))
        {
            isWandering = true;
            isSeeking = false;
        }
        
        if (isSeeking)
        {
            Seek();
        }
        if (isWandering)
        {
            TrueWander();
        }

    }
    void TrueWander()
    {
       wanderDir = transform.rotation.eulerAngles;
        wanderDir.x = 0;
        wanderDir.z = 0;
        wanderDir.y += Random.Range(-5, 7);
        tr.transform.Translate(transform.forward * speed);
        tr.transform.rotation = Quaternion.Euler(wanderDir);
    }
    void Seek()
    {
        npcPos = new Vector3( tr.transform.position.x, 0, tr.transform.position.z);       
        targetPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);
        tr.transform.Translate((Vector3.Normalize(npcPos-targetPos) *speed));
      //tr.transform.rotation = Quaternion.Euler(fu);
        
       //tr.transform.LookAt(target,Vector3.up);

    }


    void OnCollisionEnter(Collision myTarget)
    {
        if (myTarget.gameObject.tag == "Target")
        {
            Debug.Log("IHITTHETHING");
        }

    }
    void OnCollisionExit(Collision myTarget)
    {
        if (myTarget.gameObject.tag == "Target")
        {
            Debug.Log("istopped");
        }

    }
}