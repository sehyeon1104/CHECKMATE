using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static TimerEnum;
public class ArrowBlock : MonoBehaviour
{
    //화살방향 // bool같은것을 받아가지고
    
    //체스가 내방향에 있다면 성공
    //닿았는데 체스가 내방향에 없다면 데미지 달게
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

    //인터페이스로 그걸 만들까 
    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (isActive == true) yield break;
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

                    particle.Play();
                    collision.gameObject.SetActive(false);


                    //적이 막거나
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
                    //텍스트를 띄우는 함수

                    //화면 가까이 하는 코드
                    spriteArrow.SetActive(false);
                    yield return StartCoroutine(CameraZoooooooooom.Instance.CameraZoom());


                    
                    //그리고 기주야 LookChess오류 나가지고 새로운 게임오브젝트만들고 Player태그달아 
                    testing.isSpawn = false;
                    
                    //플레이어가 움지깅ㅁ
                    transform.parent.gameObject.transform.DOShakePosition(0.4f, 0.2f, 24, 1f, false, true).OnComplete(()=>
                    {
                        //함수 호출해가지고 
                        //transform.parent.gameObject.SetActive(false); //플레이어 펄스(삭제와 같은)

                        
                        spriteK.SetActive(false);

                        GameObject obj = Instantiate(breakKing, transform.position, Quaternion.identity);
     
                    });

                    //

                }

            }
         

        }
    }

}
