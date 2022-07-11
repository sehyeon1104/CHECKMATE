using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sync_Gijoo : MonoSingleton<Sync_Gijoo>
{ 
    Test test;
    AudioSource audioSource;

    public float musicBpm;
    float stdBpm = 60f;
    public float musicTemp;
    float stdTemp = 4f;

    public float tikTime = 0f;
    public float nextTime = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        test = GetComponent<Test>();
        audioSource.Play();

    }

    private void FixedUpdate()
    {
        tikTime = 60 / musicBpm /*+ (musicTemp / stdTemp)*/;
        nextTime += Time.deltaTime;

        if(nextTime>= tikTime)
        {
            StartCoroutine(PlayTik(tikTime));
            nextTime -= 60 / musicBpm;
        }
    }

    private IEnumerator PlayTik(float tikTime)
    {
        Debug.Log(nextTime);
        test.TestOffset();
        yield return new WaitForSeconds(tikTime);
    }
}
