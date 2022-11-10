using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sync_Gijoo : MonoSingleton<Sync_Gijoo>
{
    Hit test;
    [SerializeField] private Timer timer;
    [SerializeField] private AudioSource[] musics;

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
        timer.GetComponent<EasyTimer>().enabled = false;
        timer.GetComponent<NormalTimer>().enabled = false;
        timer.GetComponent<HardTimer>().enabled = false;

        switch (HighScoreManager.timerCheck)
        {
            case TimerCheck.easy:
                musicBpm = 110f;
                timer.GetComponent<EasyTimer>().enabled = true;
                break;
            case TimerCheck.normal:
                musicBpm = 128f;
                timer.GetComponent<NormalTimer>().enabled = true;
                break;
            case TimerCheck.hard:
                musicBpm = 146f;
                timer.GetComponent<HardTimer>().enabled = true;
                break;
        }
        musics[(int)HighScoreManager.timerCheck].Play();
    }
    private void Start()
    {
        test = GetComponent<Hit>();
        
        StartCoroutine(BpmSpeedUp());

    }

    private void FixedUpdate()
    {
       if(GameManager.Instance.TimeScale == 0)
       {
            musics[(int)HighScoreManager.timerCheck].Stop();
       }

        tikTime = stdBpm / realMusicBpm;

        nextTime += Time.deltaTime;

        if (nextTime >= tikTime)
        {
            if (!isParOn)
            {
                isParOn = true;
                musics[(int)HighScoreManager.timerCheck].Play();
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
            musics[(int)HighScoreManager.timerCheck].pitch = 1 + (s * 0.01f);
            realMusicBpm = musicBpm * (1 + (s * 0.01f));
        }
    }
}
