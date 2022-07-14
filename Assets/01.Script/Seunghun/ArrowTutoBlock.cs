using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTutoBlock : MonoBehaviour
{

    //ȭ����� // bool�������� �޾ư�����

    //ü���� �����⿡ �ִٸ� ����
    //��Ҵµ� ü���� �����⿡ ���ٸ� ������ �ް�
    public ArrowRotate arrowRotate;
    public AudioSource audioSource;
    public ParticleSystem particle;

    public tutoSpawner testing;

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
        if (collision.gameObject.CompareTag("Chess"))
        {
            IArrow arr = collision.gameObject.GetComponent<IArrow>();


            Debug.Log("���ʹ� arrow " + arr.GetArrowState());
            if (arr != null)
            {
                if (arrowRotate.arrow == arr.GetArrowState())
                {

                    particle.Play();
                    collision.gameObject.SetActive(false);


                    //�������� ���� ���̾�αװ� �������� ���� �� ����Ʈ�� ������
                    //���� ���ų�
                }
                else
                {
                    isActive = true;
                    audioSource.Stop();
                    GameManager.Instance.TimeScale = 0f;

                    Sync_Gijoo.Instance.IsDeadTik();
              
                    testing.isSpawn = false; //��ȯ���� ����
                    
                    
                    //���� �ƴ϶� �ִ� ������ ���ְ�
                    //�װ� �ƴ϶� �׳� �ٽý��۵ǰ� �����  //������ �װ� �����ϰ� 
                }

            }


        }
    }

}


