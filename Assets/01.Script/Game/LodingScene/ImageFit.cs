using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageFit : MonoBehaviour
{
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();   
    }
    void Start()
    {
        image.rectTransform.sizeDelta = new Vector2(Screen.width,Screen.height);
    }

    // Upd
}
