using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
public class LoadingdoText : MonoBehaviour
{
    string loadingtext;
    TextMeshProUGUI textMesh;
    private void Awake()
    {
        
        textMesh = GetComponent<TextMeshProUGUI>();
        loadingtext = "Loading...";
    }
    void Start()
    {
        StartCoroutine(SlowText(textMesh));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SlowText(TextMeshProUGUI d)
    {
        char[] chars = loadingtext.ToCharArray();
        while(true)
        {
          for(int i = 0; i < chars.Length; i++)
            {
                d.text += chars[i];
          yield return new WaitForSeconds(0.08f);
                if (i == chars.Length - 1)
                {
                    d.text = "";
                    i = -1;
                }
            }
        }
    }
}
