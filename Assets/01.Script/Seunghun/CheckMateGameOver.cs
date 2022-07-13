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


        //바로 시작이 아니라
        //체크메이트가 뜨고, 3, 2 ,1를 시작하게 만듬
    }

    
}
