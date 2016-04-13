using UnityEngine;
using System.Collections;

public class animationTest : MonoBehaviour
{
    private Transform trans;
    private float speed = 5;
    private float rotateSpeed = 100;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        trans = GameObject.Find("lemur").transform;
        anim = trans.gameObject.GetComponentInChildren<Animator>();
        Debug.Assert(anim != null);
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        trans.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        trans.Translate(Vector3.forward * velocity);
        anim.SetFloat("velocity", Mathf.Abs(velocity));
        Debug.Log(velocity);
    }
}
