using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    private void Start()
    {
        ShowDial(0);
    }
    public void ShowDial(int code)
    {
        GameManager.ShowDialog(code);
    }

}
