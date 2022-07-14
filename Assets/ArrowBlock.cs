using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static TimerEnum;
public class ArrowBlock : MonoBehaviour
{
    //ȭ����� // bool�������� �޾ư�����
    
    //ü���� �����⿡ �ִٸ� ����
    //��Ҵµ� ü���� �����⿡ ���ٸ� ������ �ް�
    public ArrowRotate arrowRotate;
    public AudioSource audioSource;
    public ParticleSystem particle;


    public TimerChek timerCheck;
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

                    particle.Play();
                    collision.gameObject.SetActive(false);


                    //���� ���ų�
                }
                else
                {

                    switch (timerCheck)
                    {
                        case TimerChek.easy:
                            Timer.Instance.copyEasyCheckTimer();
                            if (Timer.Instance.easyCheckTimer > TimePlayerpersManager.Instance.GetCheckEasyLoad())
                            {


                                TimePlayerpersManager.Instance.SaveEasy();
                            }
                            break;
                        case TimerChek.normal:


                            Timer.Instance.copyNormalCheckTimer();
                            if (Timer.Instance.normalCheckTimer > TimePlayerpersManager.Instance.GetCheckLoad())
                            {


                                TimePlayerpersManager.Instance.SaveNormal();
                            }
                            break;
                        case TimerChek.hard:


                            Timer.Instance.copyHardCheckTimer();
                            if (Timer.Instance.hardCheckTimer > TimePlayerpersManager.Instance.GetCheckHardLoad())
                            {


                                TimePlayerpersManager.Instance.SaveHard();
                            }
                            break;
                        default:
                            break;
                    }
                   
                   

                    isActive = true;
                    //collision.gameObject.SetActive(false);
                    audioSource.Stop();
                    GameManager.Instance.TimeScale = 0f;

                   Sync_Gijoo.Instance.IsDeadTik();
                    //�ؽ�Ʈ�� ���� �Լ�

                    //ȭ�� ������ �ϴ� �ڵ�
                    spriteArrow.SetActive(false);
                    yield return StartCoroutine(CameraZoooooooooom.Instance.CameraZoom());


                    
                    //�׸��� ���־� LookChess���� �������� ���ο� ���ӿ�����Ʈ����� Player�±״޾� 
                    testing.isSpawn = false;
                    
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
