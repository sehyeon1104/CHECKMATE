using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NormalTimer : Timer
{
    public override void CheckUpdate()
    {
        textTimers[0].text = $"{(int)timer / 60 % 60:00} : ";
        textTimers[1].text = $"{(int)timer % 60:00}";
        if (GameManager.Instance.TimeScale != 0)
            timer += Time.deltaTime;


        if (timer >= 122.5f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE2E;
        }
        else if (timer >= 122.4f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(1, 1, 0, 0.4f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 115.5f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE1;
        }
        else if (timer >= 115.4f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(1, 1, 0, 0.4f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 108.4f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 108.3f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(1, 1, 0, 0.4f);
                particle.Play();

            }
        }
        else if (timer >= 101.1f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 101.0f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(1, 1, 0, 0.4f);
                particle.Play();

            }
        }
        else if (timer >= 93.4f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 93.3f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(1, 1, 0, 0.4f);
                particle.Play();

            }
        }
        else if (timer >= 85.5f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE1;
        }
        else if (timer >= 85.4f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 77.2f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE1;
        }
        else if (timer >= 77.1f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 68.4f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 68.3f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(1, 1, 0, 0.4f);
                particle.Play();

            }
        }
        else if (timer >= 59.2f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 59.1f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(1, 1, 0, 0.4f);
                particle.Play();

            }
        }
        else if (timer >= 49.4f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 49.3f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(1, 1, 0, 0.4f);
                particle.Play();

            }
        }
        else if (timer >= 38.9f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE3;
        }
        else if (timer >= 38.8f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 27.5f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE2E;
        }
        else if (timer >= 27.4f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 15.1f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE2;
        }
        else if (timer >= 15.0f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 0f)
            colorMode = ColorMode.PAZE1;

        CheckState();
    }

    public override void CheckState()
    {
        switch (colorMode)
        {
            case ColorMode.MIN:
                n = 0;
                break;
            //기본색
            case ColorMode.DEFAULT:
                pawn.color = Color.blue;
                kinght.color = Color.blue;
                bishop.color = Color.blue;
                rook.color = Color.blue;
                king.color = Color.red;
                arrow.color = Color.red;
                global.color = new Color(0f, 0.5f, 1f);
                break;
            //회색에 가까운 색이됨
            case ColorMode.PAZE1:
                globalColor = new Color(0f + (n / 511f), 0.5f, 1f - (n / 511f));
                kingColor = new Color(1f, 0f + ((n * 2) / 512f), 0f + ((n * 2) / 255f));
                enemyColor = new Color(0f, 1f - ((n * 2) / 255f), 1f - ((n * 2) / 512f));
                pawn.color = enemyColor;
                kinght.color = enemyColor;
                bishop.color = enemyColor;
                rook.color = enemyColor;
                king.color = kingColor;
                arrow.color = kingColor;
                global.color = globalColor;
                break;
            
            case ColorMode.PAZE2:
                globalColor = new Color(0.125f + (n / 447f), 0.5f, 0.875f - (n / 447f));
                kingColor = new Color(1f, 0f, 0f + (n / 255f));
                enemyColor = new Color(0f, 1f, 1f - (n / 255f));
                pawn.color = enemyColor;
                kinght.color = enemyColor;
                bishop.color = enemyColor;
                rook.color = enemyColor;
                king.color = kingColor;
                arrow.color = kingColor;
                global.color = globalColor;
                break;
            case ColorMode.PAZE2E:
                globalColor = new Color(0.125f + (n / 447f), 0.5f, 0.875f - (n / 447f));
                kingColor = new Color(1f, 0f + (n / 255f), 0f);
                enemyColor = new Color(0f, 1f - (n / 255f), 1f);
                pawn.color = enemyColor;
                kinght.color = enemyColor;
                bishop.color = enemyColor;
                rook.color = enemyColor;
                king.color = kingColor;
                arrow.color = kingColor;
                global.color = globalColor;
                break;
            case ColorMode.PAZE3:
                globalColor = new Color(0.25f + (n / 383f), 0.5f, 0.75f - (n / 383f));
                kingColor = new Color(1f, 0f + (n / 255f), 0f + (n / 255f));
                enemyColor = new Color(0f, 1f - (n / 255f), 1f - (n / 255f));
                pawn.color = enemyColor;
                kinght.color = enemyColor;
                bishop.color = enemyColor;
                rook.color = enemyColor;
                king.color = kingColor;
                arrow.color = kingColor;
                global.color = globalColor;
                break;
            case ColorMode.CLIMAX:
                pawn.color = Color.yellow;
                kinght.color = Color.yellow;
                bishop.color = Color.yellow;
                rook.color = Color.yellow;
                king.color = Color.blue;
                arrow.color = Color.blue;
                global.color = new Color(1f, 0.3f, 0f);
                break;
        }
    }
}
