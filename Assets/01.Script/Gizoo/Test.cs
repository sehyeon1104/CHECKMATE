using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    CameraShake cameraShake;
    [SerializeField]
    AudioSource testSound;
    bool isParOn = false;

    public IEnumerator TestOffset()
    {
        if (!isParOn)
        {
            isParOn = true;
            yield return new WaitForSeconds(0f);
        }
        
        testSound.Play();
        cameraShake.ReSize();
        cameraShake.Shake();
    }

    public void CancleCameraShake()
    {
        cameraShake.CancleShake();
        cameraShake.CancelInvoke();
    }
}
