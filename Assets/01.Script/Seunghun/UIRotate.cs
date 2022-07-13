using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIRotate : MonoBehaviour
{
    public RectTransform rectImage;

    public float timeDeltatime;
    // Update is called once per frame
    private void Start()
    {
        rectImage.DORotate(new Vector3(0f, -90f, 0f), 0.5f, RotateMode.Fast);
    }

}
