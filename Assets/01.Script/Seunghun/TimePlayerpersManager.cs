using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlayerpersManager : MonoSingleton<TimePlayerpersManager>
{
    public Timer timer;

    public void Save()
    {
        switch(HighScoreManager.timerCheck)
        {
            case TimerCheck.easy:
                timer = FindObjectOfType<EasyTimer>();
                PlayerPrefs.SetInt("TiemrScoreEasy", (int)timer.checkTimer);
                break;
            case TimerCheck.normal:
                timer = FindObjectOfType<NormalTimer>();
                PlayerPrefs.SetInt("TiemrScore", (int)timer.checkTimer);
                break;
            case TimerCheck.hard:
                timer = FindObjectOfType<HardTimer>();
                PlayerPrefs.SetInt("TiemrScoreHard", (int)timer.checkTimer);
                break;
        }
    }

    public void Load()
    {
        switch (HighScoreManager.timerCheck)
        {
            case TimerCheck.easy:
                timer = FindObjectOfType<EasyTimer>();
                timer.checkTimer = PlayerPrefs.GetInt("TiemrScoreEasy");
                break;
            case TimerCheck.normal:
                timer = FindObjectOfType<NormalTimer>();
                timer.checkTimer = PlayerPrefs.GetInt("TiemrScore");
                break;
            case TimerCheck.hard:
                timer = FindObjectOfType<HardTimer>();
                timer.checkTimer = PlayerPrefs.GetInt("TiemrScoreHard");
                break;
        }
    }

    public int GetCheckLoad()
    {
        switch (HighScoreManager.timerCheck)
        {
            case TimerCheck.easy:
                return PlayerPrefs.GetInt("TiemrScoreEasy");
            case TimerCheck.normal:
                return PlayerPrefs.GetInt("TiemrScore");
            case TimerCheck.hard:
                return PlayerPrefs.GetInt("TiemrScoreHard");
        }
        return 0;
    }
}
