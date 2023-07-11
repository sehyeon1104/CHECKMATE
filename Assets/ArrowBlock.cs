using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowBlock : MonoBehaviour
{
    //화살방향 // bool같은것을 받아가지고

    //체스가 내방향에 있다면 성공
    //닿았는데 체스가 내방향에 없다면 데미지 달게
    public ArrowRotate arrowRotate;
    public ParticleSystem particle;
    public EnemySpawner testing;

    bool isActive = false;

    public TimerCheck timerCheck;

    public GameObject spriteK;
    public GameObject spriteArrow;
    public GameObject breakKing;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //인터페이스로 그걸 만들까 
    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (isActive == true) yield break;

        if (collision.gameObject.CompareTag("Chess"))
        {
            IArrow arr = collision.gameObject.GetComponent<IArrow>();


            if (arr != null)
            {
                if (arrowRotate.arrow == arr.GetArrowState())
                {
                    //audioSource.Play();
                    particle.Play();
                    collision.gameObject.SetActive(false);
                }
                else
                {
                    Timer.Instance.copyCheckTimer();
                    Debug.Log("타이머 : " + Timer.Instance.timer);
                    testing.GetComponent<EnemySpawner>().isSpawn = false;
                    if (Timer.Instance.checkTimer > TimePlayerpersManager.Instance.GetCheckLoad())
                    {
                        TimePlayerpersManager.Instance.Save();
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
                    yield return StartCoroutine(CameraZoomer.Instance.CameraZoom());

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