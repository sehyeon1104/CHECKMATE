using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookChess : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOMove(new Vector2(GameManager.Instance.Player.position.x, GameManager.Instance.Player.position.y), 1f).SetEase(Ease.OutQuart);
    }
}
