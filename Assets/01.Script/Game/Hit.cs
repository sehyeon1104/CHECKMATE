using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField]
    CameraShake cameraShake;
    bool isParOn = false;

    public IEnumerator TestOffset()
    {
        if (!isParOn)
        {
            isParOn = true;
            yield return new WaitForSeconds(0f);
        }
        cameraShake.ReSize();
        cameraShake.Shake();
    }

    public void CancleCameraShake()
    {
        cameraShake.CancleShake();
        cameraShake.CancelInvoke();
    }
}
