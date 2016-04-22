using UnityEngine;
using System.Collections;
using Assets._scripts;

public class Gacha : MonoBehaviour
{
    #region public properties
    public bool IsAnimated = false;
    public float idleAnimationTime;
    
    #endregion

    #region private fields
    private Timer _idleAnimationTimer;
    private Animator _animator;
    #endregion

    #region unity lifecycle methods
    void Start()
    {
        _animator = GetComponent<Animator>();
        Debug.Assert(_animator != null, "No animator component found.");
        IsAnimated = _animator.enabled;

        if (GameManager.instance.CurrentScene == GameManager.Scene.TOWN && IsAnimated)
        {
            _idleAnimationTimer = new Timer(idleAnimationTime);
            _idleAnimationTimer.Start();
            _idleAnimationTimer.onRaiseAlarmEvent += HandleIdleAnimationAlarmEvent;
        }
    }

    void Update()
    {
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
    #endregion

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
