using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBlock : MonoBehaviour
{
    //ȭ����� // bool�������� �޾ư�����

    //ü���� �����⿡ �ִٸ� ����
    //��Ҵµ� ü���� �����⿡ ���ٸ� ������ �ް�
    public ArrowRotate arrowRotate;



    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("��Ҵ�");
        if (collision.gameObject.CompareTag("Chess"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
