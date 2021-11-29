using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  [SerializeField]
  Image progressBar;
  static string nextScene;
  // Start is called before the first frame update
  //public static void LoadScene(string sceneName)
  public static void LoadScene(string sceneName)
  {
    nextScene = sceneName;
    SceneManager.LoadScene("Loading");
  }
  void Start()
  {
    StartCoroutine(LoadSceneProcess());
  }
  IEnumerator LoadSceneProcess()
  {
    AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
    op.allowSceneActivation = false;

    float timer = 0f;
    while (!op.isDone)
    {
      // yield return null;
      // if (op.progress < 0.2f)
      // {
      //   progressBar.fillAmount = op.progress;
      // }
      // else
      // {
      //   timer += Time.unscaledDeltaTime;
      //   progressBar.fillAmount = Mathf.Lerp(0.2f, 1f, timer);
      //   if (progressBar.fillAmount >= 1f)
      //   {
      //     op.allowSceneActivation = true;
      //     yield break;
      //   }
      // }
      yield return null;

      timer += Time.deltaTime;

      if (op.progress >= 0.9f)
      {
        progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

        if (progressBar.fillAmount == 1.0f)
          op.allowSceneActivation = true;
      }
      else
      {
        progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
        if (progressBar.fillAmount >= op.progress)
        {
          timer = 0f;
        }
      }
    }
  }
}
