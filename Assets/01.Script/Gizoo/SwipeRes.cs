using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeRes : MonoBehaviour
{
    // Start is called before the first frame update
    public Image rect;
    void Awake()
    {
        rect.rectTransform.sizeDelta = new Vector2(Screen.width, 1080);
        Debug.Log(Screen.width);
    }

    // Update is called once per frame
    void Update()
    {
        //rect.rectTransform.sizeDelta = new Vector2(Screen.width, 1080);
   
    }
}
