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
    //bpm��ŭ 3����
    public float bpm;
    IEnumerator Ienum()
    {
        for(int i = 0; i < beat; i++)
        {
            Debug.Log("������");
            spriteR.color = Color.black;
            yield return new WaitForSeconds(bpm);
            spriteR.color = Color.white;
            yield return new WaitForSeconds(bpm);

        }

        Instantiate(LookObj, transform.position, Quaternion.identity);
        gameObject.SetActive(false);

    }
}
