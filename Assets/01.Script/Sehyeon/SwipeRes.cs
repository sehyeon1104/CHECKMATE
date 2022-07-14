using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeRes : MonoBehaviour
{
    // Start is called before the first frame update
    public Image rect;
    Canvas canvas;

    void Awake()
    {
        rect.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        Debug.Log(Screen.width);
    }
}
