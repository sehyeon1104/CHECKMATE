using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreManager : MonoSingleton<HighScoreManager>
{
    public TextMeshProUGUI highScore;
    public TimerCheck timerCheck;

    // Start is called before the first frame update
    void Awake()
    { 
        switch (timerCheck)
        {
            case TimerCheck.easy:
                TimePlayerpersManager.Instance.EasyLoad();
                highScore.text = "Best : " + Timer.Instance.easyCheckTimer.ToString() + " sec";
                break;
            case TimerCheck.normal:
                TimePlayerpersManager.Instance.NormalLoad();
                highScore.text = "Best : " + Timer.Instance.normalCheckTimer.ToString() + " sec";
                break;
            case TimerCheck.hard:
                TimePlayerpersManager.Instance.HardLoad();
                highScore.text = "Best : " + Timer.Instance.hardCheckTimer.ToString() + " sec";
                break;
            default:
                break;
        }

    }


}
