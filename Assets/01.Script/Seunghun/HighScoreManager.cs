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
        TimePlayerpersManager.Instance.Load();
        highScore.text = "Best : " + Timer.Instance.checkTimer.ToString() + " sec";

    }


}
