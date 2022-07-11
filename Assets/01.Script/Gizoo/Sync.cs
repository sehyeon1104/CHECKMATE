using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sync : MonoSingleton<Sync>
{ 
    Test test;

    public float musicBpm;
    float stdBpm = 60f;
    public float musicTemp;
    float stdTemp = 4f;

    public float tikTime = 0f;
    public float nextTime = 0f;

    private void Start()
    {
        test = GetComponent<Test>();
    }

    private void Update()
    {
        tikTime = ((stdBpm / musicBpm) + (musicTemp / stdTemp))/4;
        nextTime += (float)Time.deltaTime;

        if(nextTime>= tikTime)
        {
            StartCoroutine(PlayTik(tikTime));
            nextTime = 0f;
        }
    }

    private IEnumerator PlayTik(float tikTime)
    {
        Debug.Log(nextTime);
        test.TestOffset();
        yield return new WaitForSeconds(tikTime);
    }
}
