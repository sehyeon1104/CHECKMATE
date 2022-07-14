using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoSingleton<Timer>
{
    enum ColorMode
    {
        DEFAULT = 0,
        PAZE1,
        PAZE2,
        PAZE3,
        MIDDLE,
        CLIMAX
    }

    public float n = 0;

    public Color bluem = new Color(0, 0, 1);
    public Color redm = new Color(1, 0, 0);
    public Color cyanm = new Color(0, 1, 1);

    [SerializeField]
    private TextMeshProUGUI[] textTimers;
    [SerializeField]
    private ParticleSystem particle;
    private bool isParOn = false;
    public float timer = 0;
    public float normalCheckTimer = 0;
    public float easyCheckTimer = 0;
    public float hardCheckTimer = 0;
    ColorMode colorMode = ColorMode.DEFAULT;

    public UnityEngine.Rendering.Universal.Light2D pawn, kinght, bishop, rook, king, arrow, global, cautionR, cautionB;

    private void Awake()
    {
        colorMode = ColorMode.DEFAULT;
        CheckState();
    }
    public void Start()
    {
        InvokeRepeating("NPlus", 0f, 0.1f);
    }

    public void NPlus()
    {
        n++;
    }


    public void copyNormalCheckTimer()
    {
        normalCheckTimer = timer;
    }
    public void copyEasyCheckTimer()
    {
        easyCheckTimer = timer;

    }
    public void copyHardCheckTimer()
    {
        hardCheckTimer = timer;
    }

    private void FixedUpdate()
    {
 
        textTimers[0].text = $"{(int)timer / 60 % 60:00} : ";
        textTimers[1].text = $"{(int)timer % 60:00}";
        if(GameManager.Instance.TimeScale != 0)
        timer += Time.deltaTime;
        


        if (timer >= 76.1f)
        {
            isParOn = false;
            colorMode = ColorMode.DEFAULT;
        }
        else if (timer >= 76.0f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();
            }
        }
        else if (timer >= 48.3f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 48.2f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(1,1,0, 0.4f);
                particle.Play();
                
            }
        }
        else if (timer >= 26.4f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE1;
        }
        else if (timer >= 26.3f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();
                colorMode = ColorMode.DEFAULT;
            }
        }
        else if (timer >= 14f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE2;
        }
        else if (timer >= 13.9f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();
                colorMode = ColorMode.DEFAULT;
            }
        }
        else if (timer >= 0f)
            colorMode = ColorMode.PAZE1;

        CheckState();
    }

    public void CheckState()
    {
        switch(colorMode)
        {
            case ColorMode.DEFAULT:
                n = 0;
                pawn.color = Color.blue;
                kinght.color = Color.blue;
                bishop.color = Color.blue;
                rook.color = Color.blue;
                king.color = Color.red;
                arrow.color = Color.red;
                global.color = Color.cyan;
                //cautionR.color = Color.red;
                //cautionB.color = Color.red;
                break;
            case ColorMode.PAZE1:
                bluem = new Color(0f + (n / 255f), 0f + (n / 255f), 1f - (n / 255f));
                redm = new Color(1f - (n / 255f), 0f + (n / 255f), 0f + (n / 255f));
                cyanm = new Color(0f + (n / 255f), 1f - (n / 255f), 1f - (n / 255f));
                Color paze1m = new Color(0f + (n / 255f), 1f, 1f - (n / 255f));
                pawn.color = bluem;
                kinght.color = bluem;
                bishop.color = bluem;
                rook.color = bluem;
                king.color = redm;
                arrow.color = redm;
                global.color = paze1m;
                //cautionR.color = Color.red;
                //cautionB.color = Color.red;
                break;
            case ColorMode.PAZE2:
                bluem = new Color(0f + (n / 255f), 0f + (n / 255f), 1f - (n / 255f));
                redm = new Color(1f - (n / 255f), 0f + (n / 255f), 0f + (n / 255f));
                cyanm = new Color(0f + (n / 255f), 1f - (n / 255f), 1f - (n / 255f));
                Color paze2m = new Color(0f + (n / 255f), 1f - (n / 255f), 1f);
                pawn.color = bluem;
                kinght.color = bluem;
                bishop.color = bluem;
                rook.color = bluem;
                king.color = redm;
                arrow.color = redm;
                global.color = paze2m;
                //cautionR.color = Color.red;
                //cautionB.color = Color.red;
                break;
            case ColorMode.MIDDLE:
                pawn.color = Color.cyan;
                kinght.color = Color.cyan;
                bishop.color = Color.cyan;
                rook.color = Color.cyan;
                king.color = Color.magenta;
                arrow.color = Color.magenta;
                global.color = Color.blue;
                //cautionR.color = Color.magenta;
                //cautionB.color = Color.magenta;
                break;
            case ColorMode.CLIMAX:
                pawn.color = Color.red;
                kinght.color = Color.red;
                bishop.color = Color.red;
                rook.color = Color.red;
                king.color = Color.blue;
                arrow.color = Color.blue;
                global.color = Color.yellow;
                //cautionR.color = Color.blue;
                //cautionB.color = Color.blue;
                break;
        }
    }    
}
