using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlayerpersManager : MonoSingleton<TimePlayerpersManager>
{
    public void Save()
    {
        switch(HighScoreManager.Instance.timerCheck)
        {
            case TimerCheck.easy:
                PlayerPrefs.SetInt("TiemrScoreEasy", (int)Timer.Instance.checkTimer);
                break;
            case TimerCheck.normal:
                PlayerPrefs.SetInt("TiemrScore", (int)Timer.Instance.checkTimer);
                break;
            case TimerCheck.hard:
                PlayerPrefs.SetInt("TiemrScoreHard", (int)Timer.Instance.checkTimer);
                break;
        }
    }

    public void Load()
    {
        switch (HighScoreManager.Instance.timerCheck)
        {
            case TimerCheck.easy:
                Timer.Instance.checkTimer = PlayerPrefs.GetInt("TiemrScoreEasy");
                break;
            case TimerCheck.normal:
                Timer.Instance.checkTimer = PlayerPrefs.GetInt("TiemrScore");
                break;
            case TimerCheck.hard:
                Timer.Instance.checkTimer = PlayerPrefs.GetInt("TiemrScoreHard");
                break;
        }
    }

    public int GetCheckLoad()
    {
        switch (HighScoreManager.Instance.timerCheck)
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
