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
        //�ؽ�Ʈ�� ���� �Լ�

        //ȭ�� ������ �ϴ� �ڵ�



        //�׸��� ���־� LookChess���� �������� ���ο� ���ӿ�����Ʈ����� Player�±״޾� 
        spawner.isSpawn = false; //��ȯ���� ����

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
        //�ݹ����ִ´� 
    }


    public void tutoSpawnTrue()
    {
        //TutoDialogManager.Instance.Load();
        spawner.StartSpawn();
    }



}
