using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public FadeScreen fade;

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));

    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fade.FadeOut();
        yield return new WaitForSeconds(fade.fadeDuration);

        SceneManager.LoadScene(sceneIndex);


    }
}
