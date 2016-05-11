using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GachaBall : MonoBehaviour
{
    public BuyGacha gachaMachine;
    Rigidbody capsule;
    Animator animator;
    bool canWin = false;
    float currentTimeBelow = 0f;
    float currentTimeAbove = 0f;
    float timeToMove = 2f;
    Vector3 startPos;
    Vector3 endPos = new Vector3(-8, 0, 0);
    Vector3 startRotation;
    Vector3 endRotation;
    Player gacha;
    List<Material> gachaMats = new List<Material>();
    bool shouldMakeTransparent = false;
    List<Color> startColor = new List<Color>();

    // Use this for initialization
    void Start()
    {
        capsule = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();


        Renderer[] renderers = GetComponentsInChildren<Renderer>();


        foreach (var render in renderers)
        {
            foreach (var mat in render.materials)
            {
                gachaMats.Add(mat);
                startColor.Add(mat.color);
            }
        }
        //startColor = renderers;
    }

    // Update is called once per frame
    void Update()
    {
        WinGacha();
        MakeTransparent();
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


            if (currentTimeBelow <= timeToMove)
            {
                currentTimeBelow += Time.deltaTime;
                capsule.transform.position = Vector3.Lerp(startPos, endPos, currentTimeBelow / timeToMove);
                //capsule.transform.Rotate(capsule.transform.rotation.eulerAngles - Vector3.Lerp(startRotation, endRotation, currentTime / timeToMove)  );
                capsule.transform.eulerAngles = new Vector3
                   (Mathf.Lerp(startRotation.x, endRotation.x, currentTimeBelow / timeToMove),
                    Mathf.Lerp(startRotation.y, endRotation.y, currentTimeBelow / timeToMove),
                    Mathf.Lerp(startRotation.z, endRotation.z, currentTimeBelow / timeToMove));
                
            }

            if (currentTimeBelow > timeToMove)
            {
                canWin = false;
                animator.SetTrigger("OpenGacha");
                shouldMakeTransparent = true;
                currentTimeBelow = 0;
                // GameObject newGacha = GameManager.Instance.GetGachaPrefab(gacha.gachaCollection[gacha.gachaCollection.Count - 1]);
                //newGacha.transform.position = endPos;


            }


            //capsule.transform.rotation = Quaternion.Euler(Vector3.forward);    

            capsule.isKinematic = true;

            //instantiate a gacha prefab to show what you got
            //Debug.Log(currentTimeAbove);
        }

    }
    public void MakeTransparent()
    {
        
        if (shouldMakeTransparent)
        {
            currentTimeAbove += Time.deltaTime;
            foreach (var mat in gachaMats)
            {
                float timeframe = .917f;
                Color newColor;
                
                newColor = mat.color;
                newColor.a = Mathf.Lerp(1, 0, currentTimeAbove / timeframe); // this is not good, but .917f is the amount of time that the animation takes to complete so it is a magic number
                mat.color = newColor;
                if (currentTimeAbove > 1)
                {
                    shouldMakeTransparent = false;
                    currentTimeAbove = 0;
                    mat.color = startColor[0];
                    mat.color = startColor[1];
                }
               
            }

        }



    }
}
