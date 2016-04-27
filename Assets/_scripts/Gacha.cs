using UnityEngine;
using System.Collections;
using Assets._scripts;
using UnityEngine.Events;


public class Gacha : MonoBehaviour
{
    #region public properties
    public bool IsAnimated = false;
    [Tooltip("Seconds between idle animation.")]
    public float idleAnimationTime;

    public Animator Animator { get; private set; }

    #endregion

    #region events

    public class OnClickEvent : UnityEvent<Gacha>{}
    public OnClickEvent OnClick;
    //public UnityEvent OnClickEvent;
    #endregion

    #region private fields
    private Timer _idleAnimationTimer;
    private Camera _mainCamera;
    #endregion

    #region unity lifecycle methods

    void Awake()
    {
        OnClick = new OnClickEvent();
    }
    void Start()
    {
        Animator = GetComponent<Animator>();
        Debug.Assert(Animator != null, "No animator component found.");
        IsAnimated = Animator.enabled;

        _mainCamera = Camera.main;



        if (GameManager.Instance.CurrentScene == GameManager.Scene.TOWN && IsAnimated)
        {
            _idleAnimationTimer = new Timer(idleAnimationTime);
            _idleAnimationTimer.Start();
            _idleAnimationTimer.onRaiseAlarmEvent += HandleIdleAnimationAlarmEvent;
        }
    }

    void Update()
    {

        UpdateClickEvent();

        if (_idleAnimationTimer != null)
        {
            _idleAnimationTimer.Update(Time.deltaTime);
        }
    }
    #endregion

    #region event handlers
    /// <summary>
    /// Idle animation timer alarm event handler
    /// (fired from _idleAnimationTimer)
    /// </summary>
    void HandleIdleAnimationAlarmEvent()
    {
        Animator.SetTrigger("Idle");
    }

    /// <summary>
    /// idle animation finished event handler 
    /// (fired at end of animation clip)
    /// </summary>
    void HandleIdleAnimationCompleteEvent()
    {
        _idleAnimationTimer.Start();
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
    /// </summary>
    void UpdateClickEvent()
    {
        bool playingSpecialAnimation = IsAnimated && Animator.GetCurrentAnimatorStateInfo(0).IsName("special");
        if (!playingSpecialAnimation && Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Gacha");
            if (Physics.Raycast(ray, out hit, 1000, mask))
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
            Animator.SetFloat("velocity", speed);
            yield return null;
        }
        Animator.SetFloat("velocity", 0);
        _idleAnimationTimer.Start();

    }
}
