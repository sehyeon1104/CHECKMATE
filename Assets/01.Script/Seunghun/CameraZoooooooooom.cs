using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraZoooooooooom : MonoSingleton<CameraZoooooooooom>
{
    Camera mainCamera;
    float minusSpeed = 0.5f;

    private void Start()
    {
        mainCamera = Camera.main;
        //StartCoroutine(CameraZoom());
    }

    public IEnumerator CameraZoom()
    {
      
        while (mainCamera.fieldOfView >= 15f)
        {
            
            minusSpeed += Time.deltaTime / 2;
            Debug.Log("ZOom �ϱ�1");
            yield return null;
            Debug.Log("ZOom �ϱ�2");
            mainCamera.fieldOfView -= minusSpeed;
        }
        minusSpeed = 0.5f;
        mainCamera.fieldOfView = 15f;
        //���⿡�� ���� ������ �ڵ带 ����

    }
}