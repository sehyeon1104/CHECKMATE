using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoSetActive : MonoBehaviour
{
    public GameObject sccdsd;
    void Start()
    {
        sccdsd.SetActive(false);
        Invoke("SetTrue", 1f);
    }

   
    public void SetTrue()
    {
        sccdsd.SetActive(true);
    }
}
