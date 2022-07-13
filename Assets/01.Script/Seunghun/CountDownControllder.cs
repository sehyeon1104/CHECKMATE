using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountDownControllder : MonoSingleton<CountDownControllder>
{

    public int countDownTime;

    public TextMeshProUGUI countDownDisPlay;
    // public Sprite[] image;
    public Color[] color;
    public Image backGroundImage;

    public void TextStart()
    {
        if (Instance != null)
        {
            StartCoroutine(CountDownToStart());
        }
        
    }

    public int spriteColor;
    IEnumerator CountDownToStart()
    {
       
        while(countDownTime > 0)
        {   

            
            countDownDisPlay.text = countDownTime.ToString();
            //backGroundImage.sprite = image[0];
            backGroundImage.color = color[spriteColor];
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);

            countDownTime--;
            spriteColor++;
        }


        //�ؽ�Ʈ �ִϸ��̼� �� ������
        yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);

        Loader.Load(Loader.Scene.Seunghun);

        countDownDisPlay.gameObject.SetActive(false);
    }
}
