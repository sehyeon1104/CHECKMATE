using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShortText : MonoBehaviour
{
    public Text textUI;
    public RectTransform trm;
    private CanvasGroup cg;

    private bool isShowing = false;

    private void Awake()
    {
        cg = GetComponent<CanvasGroup>();
    }

    public void ShowText(string text, float duration)
    {
        if (isShowing) return; //�������� �̰� ť���·� ���� ���������� ����ؾ��Ѵ�.
        textUI.text = text;
        isShowing = true;

        Sequence seq = DOTween.Sequence();
        seq.Append( DOTween.To(()=> cg.alpha, value => cg.alpha = value, 1f, 0.5f));
        seq.AppendInterval(duration);
        seq.Append(DOTween.To(() => cg.alpha, value => cg.alpha = value, 0f, 0.5f));
        seq.AppendCallback(() => isShowing = false);
    }
}
