using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoDialogManager : MonoSingleton<TutoDialogManager>
{

    public TutoStart tuto;


    public void Save()
    {
        PlayerPrefs.SetInt("Level", tuto.Level);

    }

    public void Load()
    {
        tuto.Level = PlayerPrefs.GetInt("Level");
    }
}
