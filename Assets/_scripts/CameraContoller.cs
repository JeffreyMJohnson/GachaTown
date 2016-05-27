using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CameraContoller : MonoBehaviour
{
    #region public fields
    [Tooltip("Position of camera when fully zoomed in relation to zoomed subject.")]
    public Vector3 parentOffset = Vector3.zero;
    public bool IsZooming { get; private set; }
    public class CameraZoomCompleteEvent : UnityEvent<Gacha> { }
    public CameraZoomCompleteEvent OnZoomComplete = new CameraZoomCompleteEvent();
    public UnityEvent OnZoomReturn = new UnityEvent();
    #endregion
    #region private fields
    private Transform _camera = null;
    private Vector3 _sceneCameraPosition = Vector3.zero;
    private Quaternion _sceneCameraRotation = Quaternion.identity;
    #endregion
    #region public methods
    /// <summary>
    /// Zoom camera to given subject position plus an offset
    /// </summary>
    /// <param name="subject"></param>
    public void Closeup(GameObject subject)
    {
        StartCoroutine(ZoomToSubject(subject, parentOffset));
    }

    /// <summary>
    /// Return camera to original position from previous closeup
    /// </summary>
    public void PullBackToOriginal()
    {
        if (GameManager.Instance.CurrentScene == GameManager.Scene.TOWN)
            StartCoroutine(ReturnFromZoom());
    }
    #endregion
    #region private methods
    /// <summary>
    /// Zoom camera to given subject position plus given offset, getting closer by given step value per frame.
    /// </summary>
    /// <param name="subject">GameObject camera is zooming to</param>
    /// <param name="offset">Value added to position of subject for final camera position</param>
    /// <param name="step">Percentage of the way the camera will travel per frame. e.g. .1 will move camers 10 percent of distance between start and final position per frame.</param>
    /// <returns></returns>
    private IEnumerator ZoomToSubject(GameObject subject, Vector3 offset, float step = .01f)
    {
        IsZooming = true;
        if (_camera == null)
        {
            _camera = Camera.main.transform;
        }
        _sceneCameraPosition = _camera.position;
        _sceneCameraRotation = _camera.rotation;

        Vector3 finishPosition = subject.transform.position + offset;

        float t = 0;
        while (t <= 1)
        {
            Camera.main.transform.position = Vector3.Lerp(_sceneCameraPosition, finishPosition, t);
            t += step;
            Camera.main.transform.LookAt(subject.transform.position);
            yield return null;
        }
        OnZoomComplete.Invoke(subject.GetComponent<Gacha>());
    }

    /// <summary>
    /// return the camera position to the original position before zoom
    /// </summary>
    /// <param name="original"></param>
    /// <param name="step"></param>
    /// <returns></returns>
    private IEnumerator ReturnFromZoom(float step = .01f)
    {
        Vector3 startPosition = _camera.position;
        Quaternion startRotation = _camera.rotation;
        float t = 0;
        while (t <= 1)
        {
            _camera.position = Vector3.Lerp(startPosition, _sceneCameraPosition, t);
            _camera.rotation = Quaternion.Lerp(startRotation, _sceneCameraRotation, t);
            t += step;
            yield return null;
        }
        IsZooming = false;
        OnZoomReturn.Invoke();
    }
    #endregion
}
