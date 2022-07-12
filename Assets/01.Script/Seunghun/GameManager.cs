using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{


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

}
