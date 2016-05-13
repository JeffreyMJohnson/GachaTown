using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GachaBall : MonoBehaviour
{
    public BuyGacha gachaMachine;
    Rigidbody capsule;
    Animator animator;
    bool canWin = false;
    float currentTimeCanWin = 0f;
    float currentTimeMakeTransparent = 0f;
    float currentTimeSpawnGacha = 0f;
    float timeToMove = 2f;
    Vector3 startPos;
    Vector3 endPos = new Vector3(-8, 2, 0);
    Vector3 startRotation;
    Vector3 endRotation;
    List<Material> gachaMats = new List<Material>();
    bool shouldMakeTransparent = false;
    bool shouldSpawnGacha = false;
    bool growGacha = false;
    float timeLimitPerCapsule = 3f;
    List<Color> startColor = new List<Color>();
    GachaID newGachaID;
   

    public ParticleSystem sparkles;
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
    }

    // Update is called once per frame
    void Update()
    {
        WinGacha();
        MakeGachaOpenAnimationTransparent();
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


            if (currentTimeCanWin <= timeToMove)
            {
                currentTimeCanWin += Time.deltaTime;
                capsule.transform.position = Vector3.Lerp(startPos, endPos, currentTimeCanWin / timeToMove);
                //capsule.transform.Rotate(capsule.transform.rotation.eulerAngles - Vector3.Lerp(startRotation, endRotation, currentTime / timeToMove)  );
                capsule.transform.eulerAngles = new Vector3
                   (Mathf.Lerp(startRotation.x, endRotation.x, currentTimeCanWin / timeToMove),
                    Mathf.Lerp(startRotation.y, endRotation.y, currentTimeCanWin / timeToMove),
                    Mathf.Lerp(startRotation.z, endRotation.z, currentTimeCanWin / timeToMove));

            }

            if (currentTimeCanWin > timeToMove)
            {
                canWin = false;
                animator.SetTrigger("OpenGacha");
                AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.CAPSULE_OPEN_POP);
                shouldMakeTransparent = true;
                currentTimeCanWin = 0;
                // GameObject newGacha = GameManager.Instance.GetGachaPrefab(gacha.gachaCollection[gacha.gachaCollection.Count - 1]);
                //newGacha.transform.position = endPos;


            }


            //capsule.transform.rotation = Quaternion.Euler(Vector3.forward);    

            capsule.isKinematic = true;

            //instantiate a gacha prefab to show what you got
            //Debug.Log(currentTimeAbove);
        }

    }
    public void MakeGachaOpenAnimationTransparent()
    {

        if (shouldMakeTransparent)
        {
            currentTimeMakeTransparent += Time.deltaTime;
            foreach (var mat in gachaMats)
            {
                float timeframe = .917f;
                Color newColor;

                newColor = mat.color;
                newColor.a = Mathf.Lerp(1, 0, currentTimeMakeTransparent / timeframe); // this is not good, but .917f is the amount of time that the animation takes to complete so it is a magic number
                mat.color = newColor;
                if (currentTimeMakeTransparent > 1)
                {
                    shouldMakeTransparent = false;
                    currentTimeMakeTransparent = 0;
                    mat.color = startColor[0];
                    mat.color = startColor[1];
                    GameObject newGacha = SpawnGacha();
                    Destroy(newGacha, timeLimitPerCapsule);
                    sparkles.Play();
                    StartCoroutine(GachaLifetime(timeLimitPerCapsule));
                    
                }
            }
        }
    }
    public GameObject SpawnGacha()
    {
        newGachaID = Player.Instance.gachaCollection.Last();
        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.CAPSULE_GACHA_PRESENT);
        return Instantiate(GameManager.Instance.GetGachaPrefab(newGachaID), endPos, Quaternion.LookRotation(Vector3.left, Vector3.up)) as GameObject;
        

    }
    IEnumerator GachaLifetime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gachaMachine.isGachaThere = false;
    }
    
}
