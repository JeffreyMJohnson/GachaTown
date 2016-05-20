using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
    public float SplashWaitTimer = 1;

    private void Start()
    {
        StartCoroutine(LoadMainMenu(SplashWaitTimer));
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private IEnumerator LoadMainMenu(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
