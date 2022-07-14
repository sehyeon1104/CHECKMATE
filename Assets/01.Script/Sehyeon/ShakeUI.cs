using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeUI : MonoBehaviour
{
    public GameObject[] targetUi;
    public Vector3 UiScale;

    [SerializeField]
    [Range(0.1f, 1f)] float duration = 0.5f;

    [SerializeField]
    AudioSource testSound;

    public void TestOffset()
    {
        testSound.Play();
        ReSize();
    }

    public void ReSize()
    {
        InvokeRepeating("StartResize", 0f, 0.005f);
        Invoke("StopResize", duration);
    }
    void StartResize()
    {
        foreach(var i in targetUi)
        i.transform.localScale -= new Vector3(0.5f,0.5f,0) * Time.deltaTime;
    }
    void StopResize()
    {
        CancelInvoke("StartResize");
        foreach (var i in targetUi)
            i.transform.localScale = Vector3.one;
    }
}
