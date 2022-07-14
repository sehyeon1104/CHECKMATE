using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoStart : MonoBehaviour
{
    public AudioSource audioSource;

    public tutoSpawner spawner;
    public GameObject DialogPanel;


    public int Level = 0;
    private void Start()
    {

        TutoStartMethod();
    }
    public void TutoStartMethod()
    {
        //collision.gameObject.SetActive(false);
        audioSource.Stop();
        GameManager.Instance.TimeScale = 0f;
        falseDialogCan();
        Sync_Gijoo.Instance.IsDeadTik();
        //텍스트를 띄우는 함수

        //화면 가까이 하는 코드



        //그리고 기주야 LookChess오류 나가지고 새로운 게임오브젝트만들고 Player태그달아 
        spawner.isSpawn = false; //소환하지 말게

        Invoke("TutoStartDial", 1f);
    }

    public void falseDialogCan()
    {
        DialogPanel.SetActive(false);
    }
    public void trueDialogCan()
    {
        DialogPanel.SetActive(true);
    }
    public void TutoStartDial()
    {
        trueDialogCan();
        GameManager.ShowDialog(0, tutoSpawnTrue);
        //콜백을넣는다 
    }


    public void tutoSpawnTrue()
    {
        //TutoDialogManager.Instance.Load();
        spawner.StartSpawn();
    }



}
