using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowBlock : MonoBehaviour
{
    //화살방향 // bool같은것을 받아가지고
    
    //체스가 내방향에 있다면 성공
    //닿았는데 체스가 내방향에 없다면 데미지 달게
    public ArrowRotate arrowRotate;



    //인터페이스로 그걸 만들까 
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("닿았다");
        //Debug.Log(collision.gameObject.GetComponent<IArrow>().GetArrowState());
        if (collision.gameObject.CompareTag("Chess") )
        {
            IArrow arr = collision.gameObject.GetComponent<IArrow>();


            Debug.Log("에너미 arrow " + arr.GetArrowState());
            if(arr != null)
            {
                if(arrowRotate.arrow == arr.GetArrowState())
                {

                    
                    collision.gameObject.SetActive(false);
                }


            }
         

        }
    }
}
