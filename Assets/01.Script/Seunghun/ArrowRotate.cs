using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static ChessSpawnArrowEnum;


public class ArrowRotate : MonoBehaviour
{
    public ChessArrow arrow;

    // Start is called before the first frame update
    void Start()
    {
        arrow = ChessArrow.D;
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
    bool isUpRight;
    bool isUpLeft;
    bool isDownLeft;
    bool isDownRight;

    Vector3 arrowAxis;

    bool isdiagonal;

    // Update is called once per frame
    void Update()
    {
        if (isdiagonal == true) return;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("마우스버튼");
        ////}
        //if (check)
        //{

        //x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical")

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            isUpLeft = true;
            isdiagonal = true;
            arrow = ChessArrow.AW;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            arrow = ChessArrow.DW;
            isUpRight = true;
            isdiagonal = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            isDownLeft = true;
            isdiagonal = true;
            arrow = ChessArrow.SA;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            arrow = ChessArrow.SD;
            isDownRight = true;
            isdiagonal = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isUp = true;
            arrow = ChessArrow.W;
            isdiagonal = true;
            Debug.Log("출력");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrow = ChessArrow.D;
            isRight = true;
            isdiagonal = true;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            arrow = ChessArrow.A;
            isLeft = true;
            isdiagonal = true;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrow = ChessArrow.S;
            isDown = true;
            isdiagonal = true;

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
                arrow = ChessArrow.W;
                y = 1;
                x = 0;
            }
            else if (isRight)
            {
                arrow = ChessArrow.D;
                x = 1;
                y = 0;
            }
            else if (isLeft)
            {
                arrow = ChessArrow.A;
                x = -1;
                y = 0;
            }
            else if (isDown)
            {
                arrow = ChessArrow.S;
                y = -1;
                x = 0;
            }
            else if (isUpLeft)
            {
                arrow = ChessArrow.AW;
                y = 1;
                x = -1;
            }
            else if (isUpRight)
            {
                arrow = ChessArrow.DW;
                y = 1;
                x = 1;
            }
            else if (isDownLeft)
            {
                arrow = ChessArrow.SA;
                y = -1;
                x = -1;
            }
            else if (isDownRight)
            {
                arrow = ChessArrow.SD;
                y = -1;
                x = 1;
            }

            isUp = false;
            isRight = false;
            isLeft = false;
            isDown = false;
            isUpRight = false;
            isUpLeft = false;
            isDownLeft = false;
            isDownRight = false;
            isdiagonal = false;
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
