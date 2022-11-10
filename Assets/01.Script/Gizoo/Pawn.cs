using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Pawn : ChessMal
{
    private Transform playerTransform;
    private float blockRadius = 2f;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;


        //StopCoroutine(PawnM());
        StartCoroutine(PawnM());
    }

    private IEnumerator PawnM()
    {
        while (transform.position != playerTransform.position)
        {
            
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
            Move(playerTransform, blockRadius);
        }
        Destroy(gameObject, Sync_Gijoo.Instance.tikTime);
    }

    public void Move(Transform playerTransform, float tileRad)
    {
        float transformDistX = playerTransform.position.x - transform.position.x;
        float transformDistY = playerTransform.position.y - transform.position.y;

        transform.position += new Vector3(Math.Sign(transformDistX) * GameManager.Instance.TimeScale, Math.Sign(transformDistY) * GameManager.Instance.TimeScale);
    }


    public override void ArrowCopySW(ChessSpawnArrowEnum.ChessArrow chessArrow)
    {
        base.ArrowCopySW(chessArrow); 
    }

    public override ChessSpawnArrowEnum.ChessArrow GetArrowState()
    {
        return base.GetArrowState();
    }
    //Get arrow 하는 인터페이스

}
