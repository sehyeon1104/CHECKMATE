using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool ShuttingDown = false;

    private static T instance = null;
    private static object locker = new object();

   
    public static T Instance
    {
        get
        {
            if (ShuttingDown)
            {
                Debug.LogWarning("Intance" + typeof(T) + "is destroyed. returning null.");
                //return null;
            }

            lock (locker)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                    }

                   //DontDestroyOnLoad(instance.gameObject);

                }
                else if(instance != null)
                {
                    //Destroy(instance.gameObject);
                }
            }
            return instance;
        }
    }

    private void OnApplicationQuit()
    {
        ShuttingDown = true;
    }

    private void OnDestroy()
    {
        ShuttingDown = true;
    }
}

