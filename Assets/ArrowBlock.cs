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

    //�������̽��� �װ� ����� 
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
                    Debug.Log("Ÿ�̸� : " + Timer.Instance.timer);
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
                    //�ؽ�Ʈ�� ���� �Լ�
                    //CheckMateGameOver.Instance.GameObjectSet(true);
                    testing.isSpawn = false;
                    //CountDownControllder.Instance.TextStart();
                    //SceanM.Instance.SeceanChange("Seunghun");
                    yield return StartCoroutine(CameraZoomer.Instance.CameraZoom());

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