using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMateGameOver : MonoSingleton<CheckMateGameOver>
{
    public Canvas Canv;
    private void Awake()
    {
        Canv.enabled = false;   
    }

    public void GameObjectSet(bool isSet)
    {
        Canv.enabled = isSet;
    }

    
}
