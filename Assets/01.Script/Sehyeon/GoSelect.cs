using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GoSelect : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        StartCoroutine(ColorChange());
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else

Application.Quit();
    
#endif
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SelectScene");
        }
    }
    IEnumerator ColorChange()
    {
        float colorTime = 0;
        Color32 randomColor = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256),(byte)Random.Range(0, 256),255);
        while(true)
        {
       textMeshProUGUI.color = Color.Lerp(textMeshProUGUI.color,randomColor,colorTime);
            colorTime += Time.deltaTime/52*22;
            if(colorTime>0.9f)
            {
                randomColor = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255);
                colorTime = 0f; // ==colorTime = colorTime - 0.9f
            }
            yield return null;
        }
    }
}
