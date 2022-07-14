using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoSingleton<Timer>
{
    enum ColorMode
    {
        DEFAULT = 0,
        MIDDLE,
        CLIMAX
    }

    [SerializeField]
    private TextMeshProUGUI[] textTimers;
    public float timer = 0;
    ColorMode colorMode = ColorMode.DEFAULT;

    public UnityEngine.Rendering.Universal.Light2D pawn, kinght, bishop, rook, king, arrow, global, cautionR, cautionB;

    private void Awake()
    {
        colorMode = ColorMode.DEFAULT;
        CheckState();
    }

    private void FixedUpdate()
    {
        textTimers[0].text = $"{(int)timer / 60 % 60:00} : ";
        textTimers[1].text = $"{(int)timer % 60:00}";
        timer += Time.deltaTime * 3;

        if (timer >= 48)
            colorMode = ColorMode.CLIMAX;

        else if (timer >= 30)
            colorMode = ColorMode.MIDDLE;

        CheckState();
    }

    public void CheckState()
    {
        switch(colorMode)
        {
            case ColorMode.DEFAULT:
                pawn.color = Color.blue;
                kinght.color = Color.blue;
                bishop.color = Color.blue;
                rook.color = Color.blue;
                king.color = Color.red;
                arrow.color = Color.red;
                global.color = Color.cyan;
                cautionR.color = Color.red;
                cautionB.color = Color.red;
                break;
            case ColorMode.MIDDLE:
                pawn.color = Color.cyan;
                kinght.color = Color.cyan;
                bishop.color = Color.cyan;
                rook.color = Color.cyan;
                king.color = Color.magenta;
                arrow.color = Color.magenta;
                global.color = Color.blue;
                cautionR.color = Color.magenta;
                cautionB.color = Color.magenta;
                break;
            case ColorMode.CLIMAX:
                pawn.color = Color.red;
                kinght.color = Color.red;
                bishop.color = Color.red;
                rook.color = Color.red;
                king.color = Color.blue;
                arrow.color = Color.blue;
                global.color = Color.magenta;
                cautionR.color = Color.blue;
                cautionB.color = Color.blue;
                break;
        }
    }    
}
