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
        float timers = 0;
        bool isTimeSet = false ;
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
                    op.allowSceneActivation = true;
                    timers += Time.deltaTime;
                    if(timers>3f)
                    {
                        isTimeSet=true;
                    }    
                    if(isTimeSet)
                    {
                        yield break;
                    }
                    
                }
            }
        }
    }
}
