using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoSelect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            LoadingSceneController.LoadScene("SelectScene");
           //SceneManager.LoadScene("SelectScene", LoadSceneMode.Additive);
        }
    }
}
