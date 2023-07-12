using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EasyTimer : Timer
{
    public override void CheckUpdate()
    {
        base.CheckUpdate();

        textTimers[0].text = $"{(int)timer / 60 % 60:00} : ";
        textTimers[1].text = $"{(int)timer % 60:00}";

        if (timer >= 189.4f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 189.3f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();

            }
        }
        else if (timer >= 178.1f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE2E;
        }
        else if (timer >= 178.0f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0.167f, 0.833f, 0.167f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 158.2f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 158.1f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();

            }
        }
        else if (timer >= 150.8f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE2;
        }
        else if (timer >= 150.7f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0.167f, 0.833f, 0.167f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 143.4f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 143.3f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();

            }
        }
        else if (timer >= 95.4f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE2;
        }
        else if (timer >= 95.3f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0.167f, 0.833f, 0.167f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 55.8f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 55.7f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0, 0.9f, 1, 0.4f);
                particle.Play();

            }
        }
        else if (timer >= 43.5f)
        {
            isParOn = false;
            colorMode = ColorMode.PAZE2E;
        }
        else if (timer >= 43.4f)
        {
            if (!isParOn)
            {
                isParOn = true;
                particle.startColor = new Color(0.167f, 0.833f, 0.167f);
                particle.Play();
                colorMode = ColorMode.MIN;
            }
        }
        else if (timer >= 31.3f)
        {
            isParOn = false;
            colorMode = ColorMode.CLIMAX;
        }
        else if (timer >= 31.2f)
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
            colorMode = ColorMode.PAZE2;

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
                pawn.color = Color.green;
                kinght.color = Color.green;
                bishop.color = Color.green;
                rook.color = Color.green;
                king.color = new Color(1f, 0f, 1f);
                arrow.color = new Color(1f, 0f, 1f);
                global.color = new Color(0.167f, 0.833f, 0.167f);
                break;
            //회색에 가까운 색이됨
            case ColorMode.PAZE2:
                globalColor = new Color(0.167f + (n / 511f), 0.833f, 0.167f + (n / 511f));
                kingColor = new Color(1f, 0f, 1f - (n / 255f));
                enemyColor = new Color(0f, 1f, 0f + (n / 255f));
                pawn.color = enemyColor;
                kinght.color = enemyColor;
                bishop.color = enemyColor;
                rook.color = enemyColor;
                king.color = kingColor;
                arrow.color = kingColor;
                global.color = globalColor;
                break;
            case ColorMode.PAZE2E:
                globalColor = new Color(0.167f + (n / 511f), 0.833f, 0.167f + (n / 511f));
                kingColor = new Color(1f, 0f + (n / 255f), 1f);
                enemyColor = new Color(0f, 1f - (n / 255f), 0f);
                pawn.color = enemyColor;
                kinght.color = enemyColor;
                bishop.color = enemyColor;
                rook.color = enemyColor;
                king.color = kingColor;
                arrow.color = kingColor;
                global.color = globalColor;
                break;
            case ColorMode.CLIMAX:
                pawn.color = Color.blue;
                kinght.color = Color.blue;
                bishop.color = Color.blue;
                rook.color = Color.blue;
                king.color = Color.red;
                arrow.color = Color.red;
                global.color = new Color(0f, 0.5f, 1f);
                break;
        }
    }
}
