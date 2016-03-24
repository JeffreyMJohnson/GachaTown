using UnityEngine;
using System.Collections;

public class GachaToyAI : MonoBehaviour
{
    Transform self;
    public Transform target;
    public bool isSeeking;
    public bool isWandering;
    float speed = .02f;
    Vector3 npcPos;
    Vector3 targetPos;

    Vector3 wanderDir;
    Vector3 seekDir;
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

        // npcPos = new Vector3( self.transform.position.x, 0, self.transform.position.z);       

        // targetPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);


        self.LookAt(target, self.up);
        //self.transform.rotation = Quaternion.Euler(targetPos);
        self.Translate(Vector3.Normalize( target.position- self.position ) *speed,Space.World);        
        //Debug.Log(Vector3.Normalize(npcPos - targetPos) * speed);


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