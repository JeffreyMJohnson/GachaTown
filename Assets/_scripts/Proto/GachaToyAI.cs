using UnityEngine;
using System.Collections;

public class GachaToyAI : MonoBehaviour
{
    Transform self;
    public Transform target;
    public bool isSeeking;
    public bool isWandering;
    float speed = .02f;

    Vector3 wanderDir;
    void Start()
    {
        self = GetComponent<Transform>();
      

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
        self.Translate(transform.forward * speed);
        self.transform.rotation = Quaternion.Euler(wanderDir);
       
    }
    void Seek()
    {

         self.LookAt(target, self.up);
        self.Translate(Vector3.Normalize( target.position- self.position ) *speed,Space.World);  


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