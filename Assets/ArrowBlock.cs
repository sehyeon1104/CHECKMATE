using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TimerEnum;
using DG.Tweening;

public class ArrowBlock : MonoBehaviour
{
    //화살방향 // bool같은것을 받아가지고

    //체스가 내방향에 있다면 성공
    //닿았는데 체스가 내방향에 없다면 데미지 달게
    public ArrowRotate arrowRotate;
    public ParticleSystem particle;
    public Testing testing;

    bool isActive = false;

    public TimerChek timerCheck;

    public GameObject spriteK;
    public GameObject spriteArrow;
    public GameObject breakKing;


    //인터페이스로 그걸 만들까 
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
                    //텍스트를 띄우는 함수
                    //CheckMateGameOver.Instance.GameObjectSet(true);
                    testing.isSpawn = false;
                    //CountDownControllder.Instance.TextStart();
                    //SceanM.Instance.SeceanChange("Seunghun");
                    yield return StartCoroutine(CameraZoooooooooom.Instance.CameraZoom());

                    transform.parent.gameObject.transform.DOShakePosition(0.4f, 0.2f, 24, 1f, false, true).OnComplete(() =>
                    {
                        //함수 호출해가지고 
                        //transform.parent.gameObject.SetActive(false); //플레이어 펄스(삭제와 같은)


                        spriteK.SetActive(false);

                        GameObject obj = Instantiate(breakKing, transform.position, Quaternion.identity);

                    });
                }

            }


        }
    }
}