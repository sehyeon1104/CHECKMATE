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
    float x = 0f;
    float y = 0f;

    float mijisu = 0.2f;

    bool isRotate;

    bool isUp;
    bool isRight;
    bool isLeft;
    bool isDown;

    Vector3 arrowAxis;

    void Update()
    {
        float h = (float)System.Math.Ceiling(Input.GetAxis("Horizontal") * 10f)/10;
        x = Mathf.Lerp(0f, h, 1f);
        float v = (float)System.Math.Ceiling(Input.GetAxis("Vertical") * 10f)/10;
        y = Mathf.Lerp(0f, v, 1f);

        isRotate = true;

        //    check = false;
        //    StartCoroutine(WaitForIt());
        //}

    }

    private void FixedUpdate()
    {
        Debug.Log($"X : {x}");
        Debug.Log($"Y : {y}");
        if (isRotate)
        {
            if(y >= mijisu && x == 0)
            {
                arrow = ChessArrow.W;
                y = 1f;
                x = 0f;
            }
            if (y <= -mijisu && x == 0)
            {
                arrow = ChessArrow.S;
                y = -1f;
                x = 0f;
            }
            if (y == 0 && x >= mijisu)
            {
                arrow = ChessArrow.D;
                y = 0f;
                x = 1f;
            }
            if (y == 0 && x <= -mijisu)
            {
                arrow = ChessArrow.A;
                y = 0f;
                x = -1f;
            }
            if (y >= mijisu && x >= mijisu)
            {
                arrow = ChessArrow.DW;
                y = 1f;
                x = 1f;
            }
            if (y >= mijisu && x <= -mijisu)
            {
                arrow = ChessArrow.AW;
                y = 1f;
                x = -1f;
            }
            if (y <= -mijisu && x >= mijisu)
            {
                arrow = ChessArrow.SD;
                y = -1f;
                x = 1f;
            }
            if (y <= -mijisu && x <= -mijisu)
            {
                arrow = ChessArrow.SA;
                y = -1f;
                x = -1f;
            }

            if (x == 0 && y == 0)
            {

            }
            else if(Mathf.Abs(x) % 1f == 0 && Mathf.Abs(y) % 1f == 0)
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
