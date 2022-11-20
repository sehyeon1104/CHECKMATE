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
    public TextMeshProUGUI countDownDisPlay;
    static private Color[] color;
    public Color[] easyColor;
    public Color[] normalColor;
    public Color[] hardColor;
    public Image backGroundImage;

    public Camera uiCamera;
    public MotionBlur motionBlur;

    string[] countText = { "<size=115>Ready?", "<size=150>Set", "<size=150>Go!" };

    private void Awake()
    {
        profile.TryGet(out vig);
        vig.intensity.Override(0.65f);

        profile.TryGet(out motionBlur);
        motionBlur.intensity.value = 1f;

        switch (HighScoreManager.timerCheck)
        {
            case TimerCheck.easy:
                color = easyColor;
                break;
            case TimerCheck.normal:
                color = normalColor;
                break;
            case TimerCheck.hard:
                color = hardColor;
                break;
        }

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
                vig.intensity.Override(0.65f);
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

    public int spriteColor = 0;
    IEnumerator CountDownToStart()
    {
        
        while(countDownTime > 0)
        {
            countDownDisPlay.text = countText[spriteColor];
            backGroundImage.color = color[spriteColor];
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
