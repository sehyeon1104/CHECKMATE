using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TimerEnum;
public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    TimerChek timerCheck;

    // Start is called before the first frame update
    void Start()
    {


        switch (timerCheck)
        {
            case TimerChek.easy:
                TimePlayerpersManager.Instance.EasyLoad();
                highScore.text = "highScore : " + Timer.Instance.normalCheckTimer.ToString();
                break;
            case TimerChek.normal:
                TimePlayerpersManager.Instance.NormalLoad();
                highScore.text = "highScore : " + Timer.Instance.normalCheckTimer.ToString();
                break;
            case TimerChek.hard:
                TimePlayerpersManager.Instance.HardLoad();
                highScore.text = "highScore : " + Timer.Instance.normalCheckTimer.ToString();
                break;
            default:
                break;
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
