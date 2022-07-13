using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField]
    Image progressBar;
    private void Start()
    {
        StartCoroutine(LoadScenePross()); 
    }
    public static void LoadScene(string SceneName)
    {
        nextScene = SceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    IEnumerator LoadScenePross()
    {

       AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while(!op.isDone)
        {
            yield return null;
            if(op.progress<0.1f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.deltaTime/2;
                progressBar.fillAmount = Mathf.Lerp(0.1f, 1f, timer);
                if(progressBar.fillAmount>=1f)
                {
                    yield return new WaitForSeconds(1.5f);
                    op.allowSceneActivation = true;
                    
                }
            }
        }
    }
}
