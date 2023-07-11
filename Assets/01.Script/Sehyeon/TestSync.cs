using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSync : MonoBehaviour
{
    ShakeUI shakeUI;
    public float musicBpm;
    float stdBpm = 60f;
    public float musicTemp;
    float stdTemp = 4f;

    public float tikTime = 0f;
    public float nextTime = 0f;

    private void Start()
    {
        shakeUI = GetComponent<ShakeUI>();
    }

    private void FixedUpdate()
    {

        tikTime = stdBpm / musicBpm;

        nextTime += Time.deltaTime;

        if (nextTime >= tikTime)
        {
            StartCoroutine(PlayTik(tikTime));

            nextTime -= stdBpm / musicBpm;

        }
    }

    private IEnumerator PlayTik(float tikTime)
    {
        shakeUI.TestOffset();
        yield return new WaitForSeconds(tikTime);
    }
}
