using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TimerEnum;
using DG.Tweening;

public class ArrowBlock : MonoBehaviour
{
    //ȭ����� // bool�������� �޾ư�����

    //ü���� �����⿡ �ִٸ� ����
    //��Ҵµ� ü���� �����⿡ ���ٸ� ������ �ް�
    public ArrowRotate arrowRotate;
    public ParticleSystem particle;
    public Testing testing;

    bool isActive = false;

    public TimerChek timerCheck;

    public GameObject spriteK;
    public GameObject spriteArrow;
    public GameObject breakKing;


    //�������̽��� �װ� ����� 
    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (isActive == true) yield break;
        //Debug.Log(collision.gameObject.GetComponent<IArrow>().GetArrowState());
        if (collision.gameObject.CompareTag("Chess"))
        {
            IArrow arr = collision.gameObject.GetComponent<IArrow>();


            if (arr != null)
            {
                if (arrowRotate.arrow == arr.GetArrowState())
                {
                    particle.Play();
                    collision.gameObject.SetActive(false);
                }
                else
                {

                    switch (timerCheck)
                    {
                        case TimerChek.easy:
                            Timer.Instance.copyEasyCheckTimer();
                            testing.GetComponent<Testing_E>().isSpawn = false;
                            if (Timer.Instance.easyCheckTimer > TimePlayerpersManager.Instance.GetCheckEasyLoad())
                            {


                                TimePlayerpersManager.Instance.SaveEasy();
                            }
                            break;
                        case TimerChek.normal:

                            testing.GetComponent<Testing>().isSpawn = false;
                            Timer.Instance.copyNormalCheckTimer();
                            if (Timer.Instance.normalCheckTimer > TimePlayerpersManager.Instance.GetCheckLoad())
                            {


                                TimePlayerpersManager.Instance.SaveNormal();
                            }
                            break;
                        case TimerChek.hard:

                            testing.GetComponent<Testing_H>().isSpawn = false;
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
                    collision.gameObject.SetActive(false);
                    GameManager.Instance.TimeScale = 0f;
                    spriteArrow.SetActive(false);
                    Sync_Gijoo.Instance.IsDeadTik();
                    //�ؽ�Ʈ�� ���� �Լ�
                    //CheckMateGameOver.Instance.GameObjectSet(true);
                    testing.isSpawn = false;
                    //CountDownControllder.Instance.TextStart();
                    //SceanM.Instance.SeceanChange("Seunghun");
                    yield return StartCoroutine(CameraZoooooooooom.Instance.CameraZoom());

                    transform.parent.gameObject.transform.DOShakePosition(0.4f, 0.2f, 24, 1f, false, true).OnComplete(() =>
                    {
                        //�Լ� ȣ���ذ����� 
                        //transform.parent.gameObject.SetActive(false); //�÷��̾� �޽�(������ ����)


                        spriteK.SetActive(false);

                        GameObject obj = Instantiate(breakKing, transform.position, Quaternion.identity);

                    });
                }

            }


        }
    }
}