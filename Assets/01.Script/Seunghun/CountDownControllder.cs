using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class CountDownControllder : MonoSingleton<CountDownControllder>
{
    [SerializeField]
    VolumeProfile profile;
    Vignette vig;    
    public int countDownTime;

    public TextMeshProUGUI countDownDisPlay;
    // public Sprite[] image;
    public Color[] color;
    public Image backGroundImage;
    //public Image numberImage;
    //public Sprite[] sprites;
    private void Awake()
    {
        profile.TryGet(out vig);
    }
    private void Update()
    {
        switch(countDownTime)
        {
            case 3:
                vig.intensity.Override(0.3f);
                break;
            case 2:
                vig.intensity.Override(0.6f);
                break;
            case 1:
                vig.intensity.Override(0.8f);
                break;
        }
    }
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
            //numberImage.sprite = sprites[spriteColor];
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);

            countDownTime--;
            spriteColor++;
        }


        //텍스트 애니메이션 이 끝나면
        yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);

        Loader.Load(Loader.Scene.Seunghun);

        countDownDisPlay.gameObject.SetActive(false);
    }
}
