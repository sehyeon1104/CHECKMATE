using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoSingleton<GameManager>
{


    public DialogPanel dialogPanel; //다이얼로그 패널 제어용 스크립트
    private Dictionary<int, List<TextVO>> dialogTextDictionary = new Dictionary<int, List<TextVO>>();

    public Transform Player
    {
        get
        {
            return Instance.player;

        }
    }
    public Transform player;

    private float timeScale = 1f;

    public float TimeScale
    {
        get
        {
            return Instance.timeScale;

        }
        set
        {
            Instance.timeScale = Mathf.Clamp(value, 0, 1);
        }
    }

    private void Awake()
    {
        TextAsset dJson = Resources.Load("dialogText") as TextAsset;
        GameTextDataVO textData = JsonUtility.FromJson<GameTextDataVO>(dJson.ToString());

        foreach (DialogVO vo in textData.list)
        {
            dialogTextDictionary.Add(vo.code, vo.text);
        }
    }


    public static void ShowDialog(int index, Action callback = null)
    {
        if (index >= Instance.dialogTextDictionary.Count)
        {
            return;
        }

        //해당 인덱스 의 대화를 재생하도록 함.
        Instance.dialogPanel.StartDialog(Instance.dialogTextDictionary[index], callback);
    }
}
