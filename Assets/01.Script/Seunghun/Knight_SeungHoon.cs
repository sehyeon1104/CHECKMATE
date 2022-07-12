using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_SeungHoon : MonoBehaviour
{
    private Transform playerTransform;
    private float blockRadius = 1f;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        StartCoroutine(KnightM());
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
            switch (Random.Range(0, 2))
            {
                case 0:
                    if(playerTransform.position.y - transform.position.y == 0)
                        transform.position += new Vector3(((playerTransform.position.x - transform.position.x) > 0 ? 1 : -1) * blockRadius, blockRadius);
                    else
                        transform.position += new Vector3(blockRadius, (playerTransform.position.y - transform.position.y) > 0 ? 1 : -1 * blockRadius);
                    break;
                case 1:
                    if (playerTransform.position.y - transform.position.y == 0)
                        transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : -1 * blockRadius, -blockRadius);
                    else
                        transform.position += new Vector3(-blockRadius, (playerTransform.position.y - transform.position.y) > 0 ? 1 : -1 * blockRadius);
                    break;
            }
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
            transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : (playerTransform.position.x - transform.position.x) < 0 ? -1 : 0 * blockRadius, (playerTransform.position.y - transform.position.y) > 0 ? 1 : (playerTransform.position.y - transform.position.y) < 0 ? -1 : 0 * blockRadius);
        }
    }
}
