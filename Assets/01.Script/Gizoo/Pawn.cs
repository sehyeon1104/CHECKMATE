using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
      transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 * GameManager.Instance.TimeScale : (playerTransform.position.x - transform.position.x) < 0? -1 * GameManager.Instance.TimeScale : 0 * tileRad , (playerTransform.position.y - transform.position.y) > 0 ? 1 * GameManager.Instance.TimeScale : (playerTransform.position.y - transform.position.y) < 0 ? -1 * GameManager.Instance.TimeScale : 0 * tileRad);
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
