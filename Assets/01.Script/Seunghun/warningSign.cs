using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warningSign : MonoBehaviour
{

    public GameObject LookObj;
    public SpriteRenderer spriteR;
    private void OnEnable()
    {
        StartCoroutine(Ienum());
    }

    public int beat;
    //bpm만큼 3박자
    public float bpm;
    IEnumerator Ienum()
    {
        for(int i = 0; i < beat; i++)
        {
            spriteR.color = Color.black;
            yield return new WaitForSeconds(bpm);
            spriteR.color = Color.white;
            yield return new WaitForSeconds(bpm);

        }

        Instantiate(LookObj, transform.position + transform.position * 2, Quaternion.identity);
        gameObject.SetActive(false);

    }
}
