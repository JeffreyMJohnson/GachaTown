using UnityEngine;
using System.Collections;

public class GachaToyAI : MonoBehaviour
{
    private Transform self;
    public Transform target;
    public bool isSeeking;
    public bool isWandering;
    private float speed = .02f;

    private Vector3 wanderDir;

    private void Start()
    {
        self = GetComponent<Transform>();
      

    }

    private void Update()
    {
        
        
        
    }

    private void FixedUpdate()
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

    private void TrueWander()
    {
       wanderDir = transform.rotation.eulerAngles;
        wanderDir.x = 0;
        wanderDir.z = 0;
        wanderDir.y += Random.Range(-5, 7);
        self.Translate(transform.forward * speed);
        self.transform.rotation = Quaternion.Euler(wanderDir);
       
    }

    private void Seek()
    {

         self.LookAt(target, self.up);
        self.Translate(Vector3.Normalize( target.position- self.position ) *speed,Space.World);  


    }


    private void OnCollisionEnter(Collision myTarget)
    {
        if (myTarget.gameObject.tag == "Target")
        {
            Debug.Log("IHITTHETHING");
        }

    }

    private void OnCollisionExit(Collision myTarget)
    {
        if (myTarget.gameObject.tag == "Target")
        {
            Debug.Log("istopped");
        }

    }
}