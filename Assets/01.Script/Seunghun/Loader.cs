using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public static class Loader 
{
    
    private class LoadingMonoBehaviour : MonoBehaviour { }

    public enum Scene
    {
        Seunghun,
        TestScene,
        GijooScene,


    }

    private static Action onLoaderCallback;
    private static AsyncOperation loadingAsyncOperation;

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    
}
