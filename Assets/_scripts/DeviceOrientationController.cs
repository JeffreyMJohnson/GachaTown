using UnityEngine;
using UnityEngine.Events;


public class DeviceOrientationController
{
    public enum Orientation { PORTRAIT, LANDSCAPE }

    public UnityEvent OrientationChangeEvent = new UnityEvent();

    public Orientation CurrentOrientation
    {
        get
        {
            return _currentOrientation;
        }
    }


    private Orientation _currentOrientation = Orientation.PORTRAIT;

    public void Update()
    {
        DeviceOrientation orientation = Input.deviceOrientation;
        Orientation screenOrientation = _currentOrientation;
        switch (orientation)
        {
            case DeviceOrientation.LandscapeLeft:
            case DeviceOrientation.LandscapeRight:
                screenOrientation = Orientation.LANDSCAPE;
                break;
            case DeviceOrientation.Portrait:
            case DeviceOrientation.PortraitUpsideDown:
                screenOrientation = Orientation.PORTRAIT;
                break;
        }

        if (screenOrientation == _currentOrientation) return;
        _currentOrientation = screenOrientation;
        OrientationChangeEvent.Invoke();
    }


}
