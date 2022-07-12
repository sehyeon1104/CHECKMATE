using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookChess : ChessMal
{
    private void OnEnable()
    {
        
        transform.DOMove(new Vector2(GameManager.Instance.Player.position.x, GameManager.Instance.Player.position.y), 1f).SetEase(Ease.OutQuart);
    }


    public override void ArrowCopySW(ChessSpawnArrowEnum.ChessArrow chessArrow)
    {
        base.ArrowCopySW(chessArrow); 
    }

    public override ChessSpawnArrowEnum.ChessArrow GetArrowState()
    {
        return base.GetArrowState(); 
    }
}
