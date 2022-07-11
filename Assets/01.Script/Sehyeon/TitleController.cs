using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleController : MonoBehaviour
{
    WaitForSeconds waitforseconds = new WaitForSeconds(3f);
    public float bpm;
    public Vector3 point;
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        //bpm = 60 / bpm ;
        mainCamera = Camera.main;
       
        transform.DOScale(new Vector3(1.1f, 1.1f, 0), 60 / bpm / 2).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x / 4,
                Input.mousePosition.y / 4), 0);
        gameObject.transform.position = -point;

    }
    
   
}
