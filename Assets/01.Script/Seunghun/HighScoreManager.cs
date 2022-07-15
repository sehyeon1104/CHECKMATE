using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TimerEnum;
public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TimerChek timerCheck;

    // Start is called before the first frame update
    void Awake()
    {


        switch (timerCheck)
        {
            case TimerChek.easy:
                TimePlayerpersManager.Instance.EasyLoad();
                highScore.text = "Best : " + Timer.Instance.easyCheckTimer.ToString() + " sec";
                break;
            case TimerChek.normal:

                Debug.Log("µÇÁö>");
                TimePlayerpersManager.Instance.NormalLoad();
                highScore.text = "Best : " + Timer.Instance.normalCheckTimer.ToString() + " sec";
                break;
            case TimerChek.hard:
                TimePlayerpersManager.Instance.HardLoad();
                highScore.text = "Best : " + Timer.Instance.hardCheckTimer.ToString() + " sec";
                break;
            default:
                break;
        }

    }


}
