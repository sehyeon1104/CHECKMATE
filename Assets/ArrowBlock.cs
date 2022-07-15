using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TimerEnum;


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




    //인터페이스로 그걸 만들까 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive == true) return;
        Debug.Log("닿았다");
        //Debug.Log(collision.gameObject.GetComponent<IArrow>().GetArrowState());
        if (collision.gameObject.CompareTag("Chess"))
        {
            IArrow arr = collision.gameObject.GetComponent<IArrow>();


            Debug.Log("에너미 arrow " + arr.GetArrowState());
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

                    //텍스트를 띄우는 함수
                    Debug.Log("되니");
                    CheckMateGameOver.Instance.GameObjectSet(true);
                    testing.isSpawn = false;
                    CountDownControllder.Instance.TextStart();
                    //SceanM.Instance.SeceanChange("Seunghun");
                }

            }


        }
    }
}