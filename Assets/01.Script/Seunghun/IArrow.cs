using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChessSpawnArrowEnum;

public interface IArrow 
{
    void ArrowCopySW(ChessArrow chessArrow);

    ChessArrow GetArrowState();
}
