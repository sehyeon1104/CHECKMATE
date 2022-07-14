using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookChess : ChessMal
{
    private Transform playerTransform;
    private float blockRadius = 1f;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        //yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
        Move(playerTransform, blockRadius);
    }

    private void Update()
    {
        if (transform.position == playerTransform.position)
        {
            Destroy(gameObject, Sync_Gijoo.Instance.tikTime);
        }
    }

    public void Move(Transform playerTransform, float tileRad)
    {
        transform.DOMove(transform.position + new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 4 * GameManager.Instance.TimeScale : (playerTransform.position.x - transform.position.x) < 0 ? -4 * GameManager.Instance.TimeScale : 0 * tileRad * GameManager.Instance.TimeScale, (playerTransform.position.y - transform.position.y) > 0 ? 4 * GameManager.Instance.TimeScale : (playerTransform.position.y - transform.position.y) < 0 ? -4 * GameManager.Instance.TimeScale : 0 * tileRad * GameManager.Instance.TimeScale), Sync_Gijoo.Instance.tikTime).SetEase(Ease.Linear);
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
