using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoSingleton<Timer>
{
    protected enum ColorMode
    {
        DEFAULT = 0,
        MIN,
        PAZE1,
        PAZE2,
        PAZE2E,
        PAZE3,
        CLIMAX
    }

    public float n = 0;

    public Color enemyColor = new Color(0, 0, 1);
    public Color kingColor = new Color(1, 0, 0);
    public Color globalColor = new Color(0, 1, 1);

    [SerializeField]
    protected TextMeshProUGUI[] textTimers;
    [SerializeField]
    protected ParticleSystem particle;
    protected bool isParOn = false;
    public float timer = 0;
    public float normalCheckTimer = 0;
    public float easyCheckTimer = 0;
    public float hardCheckTimer = 0;

    protected ColorMode colorMode = ColorMode.DEFAULT;

    public UnityEngine.Rendering.Universal.Light2D pawn, kinght, bishop, rook, king, arrow, global, cautionR, cautionB;

    private void Awake()
    {
        colorMode = ColorMode.DEFAULT;
        CheckState();
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

    public void Start()
    {
        InvokeRepeating("NPlus", 0f, 0.1f);
    }

    public void NPlus()
    {
        n++;
    }


    private void FixedUpdate()
    {
        CheckUpdate();
    }

    public virtual void CheckUpdate()
    {
        
    }
    public virtual void CheckState()
    {
        
    }    
}
