using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowRotate : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        check = true;
    }

    public float sped = 0;

    float angle = 0;

    bool check = true;
    float x;
    float y;

    bool isRotate;

    bool isUp;
    bool isRight;
    bool isLeft;
    bool isDown;

    Vector3 arrowAxis;
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("마우스버튼");
        ////}
        //if (check)
        //{
  



            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                isUp = true;
                Debug.Log("출력");
         
            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                isRight = true;
       
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isLeft = true;
           
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                isDown = true;
               
            }

       
            isRotate = true;
           
        //    check = false;
        //    StartCoroutine(WaitForIt());
        //}



    }

    private void FixedUpdate()
    {
        if (isRotate)
        {

            if (isUp)
            {
                
                y = 1;
                x = 0;
            }
            else if (isRight)
            {
                x = 1;
                y = 0;
            }
            else if (isLeft)
            {
                x = -1;
                y = 0;
            }
            else if (isDown)
            {
                y = -1;
                x = 0;
            }

            if(x == 1 && y == 1)
            {
                Debug.Log("출");
            }
            isUp = false;
            isRight = false;
            isLeft = false;
            isDown = false;

              arrowAxis = new Vector3(x, y, 0);

            angle = Mathf.Atan2(arrowAxis.y, arrowAxis.x) * Mathf.Rad2Deg;
            Quaternion rookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector3 rooVec = rookRotation.eulerAngles;
            //transform.rotation = Quaternion.Lerp(transform.rotation, rookRotation, 0.5f * Time.deltaTime * sped);
            transform.DORotate(rooVec, 0.2f, RotateMode.Fast);
        }

        isRotate = false;
    
    }
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.1f);
        check = true;
    }


}
