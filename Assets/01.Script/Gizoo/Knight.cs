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
            //�÷��̾� ��ġ(3,3) - �� ��ġ(0,0)�� ��, ���� (1,1)��ŭ �̵��ؾߵ�
            //�׷��ϱ� �÷��̾� ��ġ�� X��ǥ - �� ��ġ�� X��ǥ�� 0���� ũ�� 1��ŭ �̵�, 0�̸� �̵� ����, 0���� ������ -1��ŭ �̵�
            //
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
            ran = Random.Range(0, 2);
            switch (ran)
            {
                case 0:
                    if(playerTransform.position.y - transform.position.y == 0)
                    {
                        transform.position += new Vector3(((playerTransform.position.x - transform.position.x) > 0 ? 1 : -1) * blockRadius, blockRadius); // ���� ������, ���� �̵�
                        
                        //�������̸� ����
                        //�����̸� ��


                    }
                    else
                    {
                        //r = (playerTransform.position.y - transform.position.y) > 0 ? 1 : -1;
                        transform.position += new Vector3(blockRadius, (playerTransform.position.y - transform.position.y) > 0 ? 1 :  -1 * blockRadius); // ���������, �Ʒ��� ���� �̵� 
                        //1�̸� �������� 
                        //-1�̸� �Ʒ�������
                    }
                        
                    break;
                case 1:
                    if (playerTransform.position.y - transform.position.y == 0)
                    {
                        transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : -1 * blockRadius, -blockRadius); //�Ʒ� ������, ���� �̵�
                        
                    }
                    else
                    {
                        transform.position += new Vector3(-blockRadius, (playerTransform.position.y - transform.position.y) > 0 ? 1 : -1 * blockRadius); // �޹�������, �Ʒ��� �����̵�
                        
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

    //�� ���Լ��� �ؾߵǴ±���
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
