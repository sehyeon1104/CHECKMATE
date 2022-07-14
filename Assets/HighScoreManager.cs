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
                highScore.text = "highScore : " + Timer.Instance.easyCheckTimer.ToString();
                break;
            case TimerChek.normal:

                Debug.Log("µÇÁö>");
                TimePlayerpersManager.Instance.NormalLoad();
                highScore.text = "highScore : " + Timer.Instance.normalCheckTimer.ToString();
                break;
            case TimerChek.hard:
                TimePlayerpersManager.Instance.HardLoad();
                highScore.text = "highScore : " + Timer.Instance.hardCheckTimer.ToString();
                break;
            default:
                break;
        }
 
    }

 
}
