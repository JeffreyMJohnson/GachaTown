using UnityEngine;
using System.Collections;
using Assets._scripts;
using UnityEngine.Events;

public class Gacha : MonoBehaviour
{
    #region public properties
    public bool IsAnimated = false;
    public float idleAnimationTime;

    #endregion

    #region events
    public UnityEvent OnClickEvent;
    #endregion

    #region private fields
    private Timer _idleAnimationTimer;
    private Animator _animator;
    private Camera _mainCamera;
    #endregion

    #region unity lifecycle methods

    void Awake()
    {
        OnClickEvent = new UnityEvent();
    }
    void Start()
    {
         _animator = GetComponent<Animator>();
        Debug.Assert(_animator != null, "No animator component found.");
        IsAnimated = _animator.enabled;

        _mainCamera = Camera.main;

       

        if (GameManager.instance.CurrentScene == GameManager.Scene.TOWN && IsAnimated)
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
        _animator.SetTrigger("Idle");
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Gacha", "Ground");
            if (Physics.Raycast(ray, out hit, 1000, mask))
            {
                OnClickEvent.Invoke();
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
        _idleAnimationTimer.Start();

    }
}
