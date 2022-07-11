using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    CameraShake cameraShake;
    [SerializeField]
    AudioSource testSound;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            cameraShake.ReSize();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            cameraShake.Shake();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            testSound.Play();
            cameraShake.ReSize();
            cameraShake.Shake();
        }
    }
}
