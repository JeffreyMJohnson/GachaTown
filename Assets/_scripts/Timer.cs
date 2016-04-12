using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._scripts
{
    /// <summary>
    /// Timer object that raises AlarmEvent after given amount of seconds are passed.
    /// <example>
    /// <code>
    /// class MyClass : MonoBehaviour
    /// {
    ///     //create timer for 1 second alarm time.
    ///     Timer myTimer = new Timer(1);
    ///     
    ///     MyClass()
    ///     {
    ///         myTimer.onRaiseAlarmEvent += HandleMyTimerAlarm;
    ///         myTimer.Start();
    ///     }
    /// 
    ///     void HandleMyTimerAlarm()
    ///     {
    ///         Debug.Log("Alarm event Fired.");
    ///         myTimer.Reset();
    ///     }
    /// 
    ///     //the Unity Update loop
    ///     void Update()
    ///     {
    ///         //timer must have Update called every frame with deltaTime param to work
    ///         myTimer.Update(Time.deltaTime);
    ///     }
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public class Timer
    {
        #region public properties
        public float CurrentTimeLeft { get; set; }
        public float AlarmTime { get; set; }
        public bool AlarmRaised { get; set; }
        public bool Running { get; set; }
        #endregion

        #region Event Handlers
        public delegate void RaiseAlarmEventHandler();
        public event RaiseAlarmEventHandler onRaiseAlarmEvent;
        #endregion

        #region constructors
        public Timer()
        {
            AlarmTime = 0;
            CurrentTimeLeft = 0;
        }

        public Timer(float alarmTime)
        {
            AlarmTime = 0;
            CurrentTimeLeft = 0;
        }
        #endregion

        #region public API

        /// <summary>
        /// call this method in the game loop when using.
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            if (Running)
            {
                if (CurrentTimeLeft > 0)
                {
                    CurrentTimeLeft -= deltaTime;
                }
                else
                {
                    CurrentTimeLeft = AlarmTime;
                    Running = false;
                    AlarmRaised = true;
                    if (onRaiseAlarmEvent != null)
                    {
                        onRaiseAlarmEvent.Invoke();
                    }
                }
            }
        }

        /// <summary>
        /// Sets a new alarm time. This resets the timer to 'off' if running while set, and 
        /// sets alarmRaised to false;
        /// </summary>
        /// <param name="alarmTime"></param>
        public void SetAlarm(float alarmTime)
        {
            Running = false;
            AlarmTime = alarmTime;
        }

        /// <summary>
        /// Resets timer to base state
        /// </summary>
        public void Reset()
        {
            Running = false;
            AlarmRaised = false;
            CurrentTimeLeft = AlarmTime;
        }

        /// <summary>
        /// Stops the timer
        /// convenience method for setting Running property to false.
        /// </summary>
        public void Stop()
        {
            Running = false;
        }

        /// <summary>
        /// Starts timer from base state.
        /// </summary>
        public void Start()
        {
            Reset();
            Running = true;
        }

#endregion


    }
}
