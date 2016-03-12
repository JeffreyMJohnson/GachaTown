using UnityEngine;
using System.Collections;

public class GachaToyAI : MonoBehaviour
{
    Transform tr;
    public Transform target;
    public bool isSeeking;
    public bool isWandering;
    void Start()
    {
        tr = GetComponent<Transform>();

    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        //if (isWandering)
        //{
        //    TrueWander();
        //}     
        if (isSeeking)
        {
            Seek();
        }
        if (Input.GetKeyDown("space"))
        {
            isWandering = false;
            isSeeking = true;
        }

    }
    void TrueWander()
    {
        var foo = transform.rotation.eulerAngles;
        foo.x = 0;
        foo.z = 0;
        foo.y += Random.Range(-3, 5);
        tr.Translate(transform.forward * .002f);
        tr.transform.rotation = Quaternion.Euler(foo);
    }
    void Seek()
    {
        tr.Translate(Vector3.Normalize(tr.transform.position -target.transform.position)*.02f);
    }


    void OnCollisionEnter(Collision myTarget)
    {
        if (myTarget.gameObject.tag == "Target")
        {
            Debug.Log("IHITTHETHING");
        }

    }
}