using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowBlock : MonoBehaviour
{
    //ȭ����� // bool�������� �޾ư�����
    
    //ü���� �����⿡ �ִٸ� ����
    //��Ҵµ� ü���� �����⿡ ���ٸ� ������ �ް�
    public ArrowRotate arrowRotate;

    public Testing testing;

    bool isActive = false;
    public GameObject spriteK;
    public GameObject spriteArrow;
    public GameObject breakKing;

    //public UnityEngine.Rendering.Universal.Light2D king;

    //�������̽��� �װ� ����� 
    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (isActive == true) yield break;
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
                else
                {
                    
                    isActive = true;
                    collision.gameObject.SetActive(false);
                    GameManager.Instance.TimeScale = 0f;

                   Sync_Gijoo.Instance.IsDeadTik();
                    //�ؽ�Ʈ�� ���� �Լ�

                    //ȭ�� ������ �ϴ� �ڵ�
                    spriteArrow.SetActive(false);
                    yield return StartCoroutine(CameraZoooooooooom.Instance.CameraZoom());


                    
                    //�׸��� ���־� LookChess���� �������� ���ο� ���ӿ�����Ʈ����� Player�±״޾� 
                    testing.isSpawn = false; //��ȯ���� ����
                    //�÷��̾ �����뤱
                    transform.parent.gameObject.transform.DOShakePosition(0.4f, 0.2f, 24, 1f, false, true).OnComplete(()=>
                    {
                        //�Լ� ȣ���ذ����� 
                        //transform.parent.gameObject.SetActive(false); //�÷��̾� �޽�(������ ����)

                        
                        spriteK.SetActive(false);

                        GameObject obj = Instantiate(breakKing, transform.position, Quaternion.identity);
     
                    });

                    //

                }

            }
         

        }
    }

}
