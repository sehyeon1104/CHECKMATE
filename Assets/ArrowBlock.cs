using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowBlock : MonoBehaviour
{
    //ȭ����� // bool�������� �޾ư�����
    
    //ü���� �����⿡ �ִٸ� ����
    //��Ҵµ� ü���� �����⿡ ���ٸ� ������ �ް�
    public ArrowRotate arrowRotate;



    //�������̽��� �װ� ����� 
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("��Ҵ�");
        //Debug.Log(collision.gameObject.GetComponent<IArrow>().GetArrowState());
        if (collision.gameObject.CompareTag("Chess") )
        {
            IArrow arr = collision.gameObject.GetComponent<IArrow>();


            Debug.Log("���ʹ� arrow " + arr.GetArrowState());
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
