using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets._scripts;
using UnityEngine.Events;


public class Gacha : MonoBehaviour
{
    
    public enum Animation { Idle, Walk, Special}
    #region public properties
    public bool IsAnimated = false;
    public Sprite gachaUI = null;
    public GachaID ID;
    #endregion

    #region events

    [System.Serializable]
    public class OnClickEvent : UnityEvent<Gacha>{}

    [SerializeField]
    public OnClickEvent OnClick;

    //public UnityEvent OnClickEvent;
    #endregion

    #region private fields
    private Camera _mainCamera;
    private Collider _collider;
    private Animator _animator;
    #endregion

    #region public API

    /// <summary>
    /// Sets and starts the given particle effect prefab
    /// note this called by animation controller when starting animation
    /// </summary>
    /// <param name="effectPrefab"></param>
    public void PlaySpecialAnimationEffect(GameObject effectPrefab)
    {
        GameObject particleInstance = GameObject.Instantiate<GameObject>(effectPrefab);
        ParticleSystem effects = particleInstance.GetComponent<ParticleSystem>();
        particleInstance.transform.position = transform.position;
        effects.Play();
        Destroy(particleInstance, effects.duration);
    }

    /// <summary>
    /// Play the given animation for this object
    /// </summary>
    /// <param name="animation"></param>
    public void PlayAnimation(Animation animation)
    {
        switch (animation)
        {
            case Animation.Idle:
                _animator.SetTrigger("Idle");
                break;
                case Animation.Special:
                _animator.SetTrigger("special");
                break;
        }
    }
#endregion

    #region unity lifecycle methods

    void Awake()
    {
        OnClick = new OnClickEvent();

        _collider = GetComponent<Collider>();
        Debug.Assert(_collider != null, "collider not found.");

        _animator = GetComponent<Animator>();
        Debug.Assert(_animator != null, "No animator component found.");

        IsAnimated = _animator.enabled;

        _mainCamera = Camera.main;
    }
    
    void Update()
    {

        UpdateClickEvent();
    }
    #endregion

    #region event handlers
    /// <summary>
    /// Idle animation timer alarm event handler
    /// (fired from _idleAnimationTimer)
    /// </summary>
    void HandleIdleAnimationAlarmEvent()
    {
        PlayAnimation(Animation.Idle);
    }

    /// <summary>
    /// special animation finished handler
    /// </summary>
    void HandleSpecialAnimationCompleteEvent()
    {

    }
    #endregion

    /// <summary>
    /// fires OnClickEvent if this gacha is clicked.
    /// note the Gacha prefab needs layer to be 'Gacha'and a 3d collider for this to work
    /// </summary>
    void UpdateClickEvent()
    {
        bool playingSpecialAnimation = IsAnimated && _animator.GetCurrentAnimatorStateInfo(0).IsName("special");
        if (!playingSpecialAnimation && Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Gacha");
            if (Physics.Raycast(ray, out hit, 1000, mask) && hit.collider == _collider)
            {
                OnClick.Invoke(this);
            }
        }
    }


    IEnumerator WalkForward()
    {
        for (Timer timer = new Timer(1, true); timer.AlarmRaised == false; timer.Update(Time.deltaTime))
        {
            float speed = 5 * Time.deltaTime;
            transform.Translate(Vector3.forward * speed);
            _animator.SetFloat("velocity", speed);
            yield return null;
        }
        _animator.SetFloat("velocity", 0);

    }
}
