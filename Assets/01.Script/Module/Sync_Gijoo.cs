using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sync_Gijoo : MonoSingleton<Sync_Gijoo>
{
    Hit test;
    AudioSource audioSource;

    public float musicBpm;
    public float realMusicBpm;
    float stdBpm = 60f;
    public float musicTemp;
    float stdTemp = 4f;

    public float tikTime = 0f;
    public float nextTime = 0f;
    bool isParOn = false;
    
    private void Awake()
    {
        switch (HighScoreManager.timerCheck)
        {
            case TimerCheck.easy:
                musicBpm = 110f;
                break;
            case TimerCheck.normal:
                musicBpm = 128f;
                break;
            case TimerCheck.hard:
                musicBpm = 146f;
                break;
        }

    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        test = GetComponent<Hit>();
        
        StartCoroutine(BpmSpeedUp());

    }

    private void FixedUpdate()
    {
       if(GameManager.Instance.TimeScale == 0)
       {
            audioSource.Stop();
       }

        tikTime = stdBpm / realMusicBpm;

        nextTime += Time.deltaTime;

        if (nextTime >= tikTime)
        {
            if (!isParOn)
            {
                isParOn = true;
                audioSource.Play();
            }
            StartCoroutine(PlayTik(tikTime));

            nextTime -= stdBpm / realMusicBpm;

        }
    }

    bool isDeadTik = false;

    public void IsDeadTik()
    {
        isDeadTik = true;
    }
    private IEnumerator PlayTik(float tikTime)
    {
        if (isDeadTik == true)
        {

            test.CancleCameraShake();
            yield break;
        }

        
        //¹¹¹¹ÇÏ¸é ¾ø¾Ö±â
        //Debug.Log(nextTime);
        //test.TestOffset();
        StartCoroutine(test.TestOffset());
        yield return new WaitForSeconds(tikTime);
    }

    int s = 0;
    private IEnumerator BpmSpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            s++;
            audioSource.pitch = 1 + (s * 0.01f);
            realMusicBpm = musicBpm * (1 + (s * 0.01f));
        }
    }
}
