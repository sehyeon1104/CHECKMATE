using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowBlock : MonoBehaviour
{
    //ȭ����� // bool�������� �޾ư�����
    
    //ü���� �����⿡ �ִٸ� ����
    //��Ҵµ� ü���� �����⿡ ���ٸ� ������ �ް�
    public ArrowRotate arrowRotate;
    public ParticleSystem particle;
    public Testing testing;

    bool isActive = false;
    //�������̽��� �װ� ����� 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive == true) return;
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
                    particle.Play();
                    collision.gameObject.SetActive(false);
                }
                else
                {
                    isActive = true;
                    collision.gameObject.SetActive(false);
                    GameManager.Instance.TimeScale = 0f;

                    //�ؽ�Ʈ�� ���� �Լ�
                    PlayerPrefs.GetFloat("Timer");
                    Debug.Log("�Ǵ�");
                    CheckMateGameOver.Instance.GameObjectSet(true);
                    testing.isSpawn = false;
                    CountDownControllder.Instance.TextStart();
                    //SceanM.Instance.SeceanChange("Seunghun");
                }

            }
         

        }
    }
}
