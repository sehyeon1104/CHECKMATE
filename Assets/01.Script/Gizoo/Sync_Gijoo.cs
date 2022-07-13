using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sync_Gijoo : MonoSingleton<Sync_Gijoo>
{
    Test test;
    AudioSource audioSource;

    public float musicBpm;
    public float realMusicBpm;
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
        StartCoroutine(BpmSpeedUp());

    }

    private void FixedUpdate()
    {

        tikTime = stdBpm / realMusicBpm;

        nextTime += Time.deltaTime;

        if (nextTime >= tikTime)
        {
            StartCoroutine(PlayTik(tikTime));

            nextTime -= stdBpm / realMusicBpm;

        }
    }

    private IEnumerator PlayTik(float tikTime)
    {
        Debug.Log(nextTime);
        test.TestOffset();
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
