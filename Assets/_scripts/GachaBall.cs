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
    bool isWaiting = false;


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
        //MakeGachaOpenAnimationTransparent();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.gameObject.name == "GachaWin")
        {
            if (capsule.velocity.x < .1 && capsule.velocity.x > -.1 && !canWin)
            {
                canWin = true;
                // TODO: Start your coroutine here!
                startPos = capsule.transform.position;
                startRotation = capsule.transform.rotation.eulerAngles;
                endRotation.Set(0, -90, 0);
            }
        }
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "TriggerShake")
        {
            animator.SetTrigger("WaitToOpen");
        }
    }

    // TODO:    Turn this into a coroutine. Not the best solution, but it's the quickest way to remedy this.
    //          Could probably advise better in a code review.
    public void WinGacha()
    {

        if (canWin)
        {



            //doing raycast here to find drop point. the coinslot collider doesn't belong to this object so the OnMouseUp function wont work here
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);



            if (currentTimeCanWin < timeToMove)
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
                capsule.isKinematic = true;


                foreach (RaycastHit hit in hits)
                {
                    


                    //if dragged coin is null then we're just clicking on the button without dragging, it hits this anyways because ondragrelease doesn't exist
                    if (hit.collider.gameObject.name == "gachacapsule_animation" && Input.GetMouseButtonUp(0))
                    {
                        

                        canWin = false;
                        animator.SetTrigger("OpenGacha");
                        AudioManager.Instance.SoundEffectsPlay(AudioManager.SoundEffect.CAPSULE_OPEN_POP);
                        //shouldMakeTransparent = true;
                        StartCoroutine(MakeTransparent(.917f));
                        currentTimeCanWin = 0;
                        capsule.isKinematic = true;
                        

                    }

                }
            }
        }
    }

    IEnumerator MakeTransparent(float duration)
    {
        float timeElapsed = 0.0f;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            foreach (var mat in gachaMats)
            {
                Color newColor;
                newColor = mat.color;
                newColor.a = Mathf.Lerp(1, 0, timeElapsed / duration); // this is not good, but .917f is the amount of time that the animation takes to complete so it is a magic number
                mat.color = newColor;

                if (timeElapsed > 1)
                {
                    shouldMakeTransparent = false;
                    
                    mat.color = startColor[0];
                    mat.color = startColor[1];
                }
            }
            yield return null;
        }

        //HACK: gotta set all the mats' alphas to 1 again since we're done and we're gonna hide the ball again
        foreach (var mat in gachaMats)
        {
            Color newColor;
            newColor = mat.color;
            newColor.a = 1;
            mat.color = newColor;
        }

        GameObject newGacha = SpawnGacha();
        Destroy(newGacha, timeLimitPerCapsule);
        sparkles.Play();
        StartCoroutine(GachaLifetime(timeLimitPerCapsule));
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
