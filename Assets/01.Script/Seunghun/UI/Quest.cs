using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Quest
{

    //�̰����� ��ũ���ͺ� ������Ʈ�� �ϴ°���?
    //��ũ���ͺ��� �������� ���� Editor�� �����ϴ°Ű�
    //������ ������ �����ϸ鼭�ذ��ϰ�
    //�׷����� ������ ���� ����
    public bool isActive;

    public string title;
    public string description;
    public int experienceReward;
    public int goldReward;

    public QuestGoal goal;
    //�ƺ����ִ� â 
    //����â 
    //������â ����
    //�̰����� �����ִ� â�� 
    //����â�� ���������� 
    //title�� �ְ�
    //������ �̰� ������ �̰� �Ѵٸ��� �ö󰡰� ���ϸ��� ���� ��ȯ�ϴ� ������� �Ѵ�.
}
