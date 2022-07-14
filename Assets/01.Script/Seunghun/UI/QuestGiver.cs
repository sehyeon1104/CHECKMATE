using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    //�÷��̾������� ��ũ���ͺ�� �ؼ� �����ұ� 
    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI goldText;
   // public PlayerMove playerMove;


    //�ڱ⿡���� �ٸ��� ǥ��
    //������ �����ִ� �� �Բ����� �ʰ���
    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.experienceReward.ToString();
        goldText.text = quest.goldReward.ToString();
    }


    //����Ʈ����� Ŭ������ ���������� ��ư�������� Ȯ�����ִ� �����ΰ�
    
    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true; //�����ϱ� bool�� UI�� �װǰ� 
        //give to player
        //playerMove.quest = quest;

        //�ٸ� Ŭ�������ٰ� Ŭ������ �����ִ� ������ ���� 
        
    }
}
