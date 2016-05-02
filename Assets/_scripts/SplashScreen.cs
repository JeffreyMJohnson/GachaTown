using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
    public float SplashWaitTimer = 1;

    void Start()
    {
        StartCoroutine(LoadMainMenu(SplashWaitTimer));
    }

    IEnumerator LoadMainMenu(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
