using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    CameraShake cameraShake;
    [SerializeField]
    AudioSource testSound;

    public void TestOffset()
    {
        testSound.Play();
        cameraShake.ReSize();
        //cameraShake.Shake();
    }
}
