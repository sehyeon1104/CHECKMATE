using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTutoBlock : MonoBehaviour
{

    //화살방향 // bool같은것을 받아가지고

    //체스가 내방향에 있다면 성공
    //닿았는데 체스가 내방향에 없다면 데미지 달게
    public ArrowRotate arrowRotate;
    public AudioSource audioSource;
    public ParticleSystem particle;

    public tutoSpawner testing;

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


                    //끝나면은 다음 다이얼로그가 나오도록 만듬 그 퀘스트가 끝나면
                    //적이 막거나
                }
                else
                {
                    isActive = true;
                    audioSource.Stop();
                    GameManager.Instance.TimeScale = 0f;

                    Sync_Gijoo.Instance.IsDeadTik();
              
                    testing.isSpawn = false; //소환하지 말게
                    
                    
                    //신이 아니라 있는 폰들을 없애고
                    //그게 아니라 그냥 다시시작되게 만들까  //레벨과 그건 저장하고 
                }

            }


        }
    }

}


