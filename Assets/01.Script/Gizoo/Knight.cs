using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessMal
{
    private Transform playerTransform;
    private float blockRadius = 1f;
    public int ran;
    public int rl;
    public int ws;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        StartCoroutine(KnightM());
    }

    private void Update()
    {
        rl = (playerTransform.position.x - transform.position.x) > 0 ? 1 : (playerTransform.position.x - transform.position.x) < 0 ? -1 : 0;
        ws = (playerTransform.position.y - transform.position.y) > 0 ? 1 : (playerTransform.position.y - transform.position.y) < 0 ? -1 : 0;

        if (rl == 1 && ws == 0)
        {
            arrow = ChessSpawnArrowEnum.ChessArrow.A;

        }
        else if (rl == -1 && ws == 0)
        {
            arrow = ChessSpawnArrowEnum.ChessArrow.D;
        }
        else if (ws == 1 && rl == 0)
        {
            arrow = ChessSpawnArrowEnum.ChessArrow.S;
        }
        else if (ws == -1 && rl == 0)
        {
            arrow = ChessSpawnArrowEnum.ChessArrow.W;
        }
    }
    private IEnumerator KnightM()
    {
        while (transform.position != playerTransform.position)
        {
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
            transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : (playerTransform.position.x - transform.position.x) < 0 ? -1 : 0 * blockRadius, (playerTransform.position.y - transform.position.y) > 0 ? 1 : (playerTransform.position.y - transform.position.y) < 0 ? -1 : 0 * blockRadius);
            //플레이어 위치(3,3) - 폰 위치(0,0)일 때, 폰은 (1,1)만큼 이동해야됨
            //그러니까 플레이어 위치의 X좌표 - 폰 위치의 X좌표가 0보다 크면 1만큼 이동, 0이면 이동 안함, 0보다 작으면 -1만큼 이동
            //
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
            ran = Random.Range(0, 2);
            switch (ran)
            {
                case 0:
                    if(playerTransform.position.y - transform.position.y == 0)
                    {
                        transform.position += new Vector3(((playerTransform.position.x - transform.position.x) > 0 ? 1 : -1) * blockRadius, blockRadius); // 위로 오른쪽, 왼쪽 이동
                        
                        //오른쪽이면 오른
                        //왼쪽이면 왼


                    }
                    else
                    {
                        //r = (playerTransform.position.y - transform.position.y) > 0 ? 1 : -1;
                        transform.position += new Vector3(blockRadius, (playerTransform.position.y - transform.position.y) > 0 ? 1 :  -1 * blockRadius); // 우방향으로, 아래쪽 위쪽 이동 
                        //1이면 위쪽으로 
                        //-1이면 아래쪽으로
                    }
                        
                    break;
                case 1:
                    if (playerTransform.position.y - transform.position.y == 0)
                    {
                        transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : -1 * blockRadius, -blockRadius); //아래 오른쪽, 왼쪽 이동
                        
                    }
                    else
                    {
                        transform.position += new Vector3(-blockRadius, (playerTransform.position.y - transform.position.y) > 0 ? 1 : -1 * blockRadius); // 왼방향으로, 아래쪽 위쪽이동
                        
                    }
                        
                    break;
            }
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
            transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : (playerTransform.position.x - transform.position.x) < 0 ? -1 : 0 * blockRadius, 
                (playerTransform.position.y - transform.position.y) > 0 ? 1 : (playerTransform.position.y - transform.position.y) < 0 ? -1 : 0 * blockRadius);


            rl = ( playerTransform.position.x - transform.position.x) > 0 ? 1 : (playerTransform.position.x - transform.position.x) < 0 ? -1 : 0;
            ws = (playerTransform.position.y - transform.position.y) > 0 ? 1 : (playerTransform.position.y - transform.position.y) < 0 ? -1 : 0;


        }
        Destroy(gameObject,Sync_Gijoo.Instance.tikTime);
    }

    //아 그함수로 해야되는구나
    public override void ArrowCopySW(ChessSpawnArrowEnum.ChessArrow chessArrow)
    {
        base.ArrowCopySW(chessArrow);
        arrow = ChessSpawnArrowEnum.ChessArrow.N;


       

    }


    

    public override ChessSpawnArrowEnum.ChessArrow GetArrowState()
    {
        return base.GetArrowState(); 
    }
}
