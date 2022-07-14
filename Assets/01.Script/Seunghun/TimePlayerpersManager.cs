using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlayerpersManager : MonoSingleton<TimePlayerpersManager>
{


    public void SaveNormal()
    {
        PlayerPrefs.SetInt("TiemrScore", (int)Timer.Instance.normalCheckTimer);

    }
    public void SaveEasy()
    {
        PlayerPrefs.SetInt("TiemrScoreEasy", (int)Timer.Instance.easyCheckTimer);

    }
    public void SaveHard()
    {
        PlayerPrefs.SetInt("TiemrScoreHard", (int)Timer.Instance.hardCheckTimer);

    }

    public void NormalLoad()
    {
        Timer.Instance.normalCheckTimer = PlayerPrefs.GetInt("TiemrScore");
    }
    public void EasyLoad()
    {
        Timer.Instance.easyCheckTimer = PlayerPrefs.GetInt("TiemrScoreEasy");
    }
    public void HardLoad()
    {
        Timer.Instance.hardCheckTimer = PlayerPrefs.GetInt("TiemrScoreHard");
    }

    public int GetCheckLoad()
    {
        return PlayerPrefs.GetInt("TiemrScore");
    }

    public int GetCheckEasyLoad()
    {
        return PlayerPrefs.GetInt("TiemrScoreEasy");
    }

    public int GetCheckHardLoad()
    {
        return PlayerPrefs.GetInt("TiemrScoreHard");
    }
}
