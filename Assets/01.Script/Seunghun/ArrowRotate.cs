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
    float x = 0;
    float y = 0;

    bool isRotate;

    bool isUp;
    bool isRight;
    bool isLeft;
    bool isDown;

    Vector3 arrowAxis;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        x = Mathf.Lerp(x, h, 1f);
        float v = Input.GetAxisRaw("Vertical");
        y = Mathf.Lerp(y, v, 1f);

        isRotate = true;

        //    check = false;
        //    StartCoroutine(WaitForIt());
        //}

    }

    private void FixedUpdate()
    {
        Debug.Log($"X : {x}");
        if (isRotate)
        {
            if(y >= 0.25f && x == 0)
            {
                arrow = ChessArrow.W;
            }
            if (y <= -0.25f && x == 0)
            {
                arrow = ChessArrow.S;
            }
            if (y == 0 && x >= 0.25f)
            {
                arrow = ChessArrow.D;
            }
            if (y == 0 && x <= -0.25f)
            {
                arrow = ChessArrow.A;
            }
            if (y >= 0.25f && x >= 0.25f)
            {
                arrow = ChessArrow.DW;
            }
            if (y >= 0.25f && x <= -0.25f)
            {
                arrow = ChessArrow.AW;
            }
            if (y <= -0.25f && x >= 0.25f)
            {
                arrow = ChessArrow.SD;
            }
            if (y <= -0.25f && x <= -0.25f)
            {
                arrow = ChessArrow.SA;
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
