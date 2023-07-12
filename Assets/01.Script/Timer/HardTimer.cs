using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HardTimer : Timer
{
    public override void CheckUpdate()
    {
        base.CheckUpdate();

        textTimers[0].text = $"{(int)timer / 60 % 60:00} : ";
        textTimers[1].text = $"{(int)timer % 60:00}";

        if (GameManager.Instance.TimeScale == 0 && timer >= 0f)
            colorMode = ColorMode.CLIMAX;

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
                pawn.color = Color.yellow;
                kinght.color = Color.yellow;
                bishop.color = Color.yellow;
                rook.color = Color.yellow;
                king.color = Color.red;
                arrow.color = Color.red;
                global.color = new Color(1f, 0.3f, 0f);
                break;
            //회색에 가까운 색이됨
            case ColorMode.PAZE2:
                new Color(1f, 0.167f, 0.167f);
                globalColor = new Color(1f - (n / 512f), 0.3f, 0f + (n / 511f));
                kingColor = new Color(1f, 0f, 0f + (n / 255f));
                enemyColor = new Color(1f, 0f, 0f + (n / 255f));
                pawn.color = enemyColor;
                kinght.color = enemyColor;
                bishop.color = enemyColor;
                rook.color = enemyColor;
                king.color = kingColor;
                arrow.color = kingColor;
                global.color = globalColor;
                break;
            case ColorMode.PAZE2E:
                globalColor = new Color(1f - (n / 512f), 0.3f, 0f + (n / 511f));
                kingColor = new Color(1f, 0f + (n / 255f), 0f);
                enemyColor = new Color(1f, 0f + (n / 255f), 0f);
                pawn.color = enemyColor;
                kinght.color = enemyColor;
                bishop.color = enemyColor;
                rook.color = enemyColor;
                king.color = kingColor;
                arrow.color = kingColor;
                global.color = globalColor;
                break;
            case ColorMode.CLIMAX:
                pawn.color = Color.red;
                kinght.color = Color.red;
                bishop.color = Color.red;
                rook.color = Color.red;
                king.color = new Color(1f, 1f, 0f);
                arrow.color = new Color(1f, 1f, 0f);
                global.color = new Color(1f, 0.167f, 0.167f);
                break;
        }
    }
}
