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
    IEnumerator Ienum()
    {
        for(int i = 0; i < beat; i++)
        {
            spriteR.color = Color.black;
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
            spriteR.color = Color.white;
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);

        }

        Instantiate(LookObj, transform.position, Quaternion.identity);
        gameObject.SetActive(false);

    }
}
