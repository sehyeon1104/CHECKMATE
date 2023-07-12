using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreManager : MonoSingleton<HighScoreManager>
{
    public TextMeshProUGUI highScore;
    public static TimerCheck timerCheck;

    // Start is called before the first frame update
    void Start()
    {
        TimePlayerpersManager.Instance.Load();
        Debug.Log(timerCheck);
        highScore.text = "Best : " + TimePlayerpersManager.Instance.timer.checkTimer.ToString() + " sec";

    }


}
