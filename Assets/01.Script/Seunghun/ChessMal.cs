using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChessSpawnArrowEnum;

public abstract class ChessMal : MonoBehaviour, IArrow
{

    public ChessArrow arrow;
    public virtual void ArrowCopySW(ChessSpawnArrowEnum.ChessArrow chessArrow)
    {
        arrow = chessArrow;
    }

    public virtual ChessSpawnArrowEnum.ChessArrow GetArrowState()
    {
        return arrow;
    }
}
