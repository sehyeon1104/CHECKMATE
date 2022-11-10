using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelOrder : MonoBehaviour
{
    WaitForSeconds waitScene = new WaitForSeconds(1f);
    public Animator transition;
    void Update()
    {
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return waitScene;

        SceneManager.LoadScene(levelIndex);
    }
}
