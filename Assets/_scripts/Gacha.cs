using UnityEngine;
using System.Collections;
using Assets._scripts;

public class Gacha : MonoBehaviour
{
    public bool IsAnimated = false;
    public float animationTimerAlarm = 3;
    private Timer animationTimer;

    #region unity lifecycle methods

    void Start()
    {
        Animator anim = GetComponent<Animator>();
        Debug.Assert(anim != null, "No animator component found.");
        IsAnimated = anim.enabled;
        if (IsAnimated)
        {
            animationTimer = new Timer(animationTimerAlarm);
            animationTimer.Start();
            animationTimer.onRaiseAlarmEvent += HandleAnimationAlarmEvent;
        }
        Debug.Log(name + " is animated:" + IsAnimated);
    }

    void Update()
    {
        if (animationTimer != null)
        {
            animationTimer.Update(Time.deltaTime);
        }

    }


    #endregion

    void HandleAnimationAlarmEvent()
    {
        StartCoroutine(WalkForward());
    }

    IEnumerator WalkForward()
    {
        for (Timer timer = new Timer(1, true); timer.AlarmRaised == false; timer.Update(Time.deltaTime))
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }
        animationTimer.Start();

    }
}
