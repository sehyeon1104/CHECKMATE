using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanM : MonoSingleton<SceanM>
{
   
    public void SeceanChange(string name)
    {
        SceneManager.LoadScene(name);
    }

    
}
