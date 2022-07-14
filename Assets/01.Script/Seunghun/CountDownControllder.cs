using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
public class CountDownControllder : MonoSingleton<CountDownControllder>
{
    [SerializeField]
    VolumeProfile profile;
    Vignette vig;    
    public int countDownTime;
    MotionBlur volum;
    public TextMeshProUGUI countDownDisPlay;
    // public Sprite[] image;
    public Color[] color;
    public Image backGroundImage;
    //public Image numberImage;

    public Camera uiCamera;
    public MotionBlur motionBlur;

    //public Sprite[] sprites;
    private void Awake()
    {
        profile.TryGet(out vig);


        profile.TryGet(out motionBlur);
    }

    bool isCount = false;




    private void Update()
    {
        if (isCount == false) return;

        switch (countDownTime)
        {
            case 3:
                vig.intensity.Override(0.233f);
                break;
            case 2:
                vig.intensity.Override(0.467f);
                break;
            case 1:
                vig.intensity.Override(0.7f);
                break;
                
        }

    }
    public void TextStart()
    {
        if (Instance != null)
        {
            isCount = true;

            var cameraData = uiCamera.GetUniversalAdditionalCameraData();
            cameraData.renderPostProcessing = true;

            cameraData.renderType = CameraRenderType.Overlay;
            motionBlur.intensity.value = 0f;


            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(uiCamera);
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


        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        

        countDownDisPlay.gameObject.SetActive(false);
    }
}
