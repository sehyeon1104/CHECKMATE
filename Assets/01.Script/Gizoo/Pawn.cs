using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    private Transform playerTransform;
    private float blockRadius = 1f;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
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
      transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : (playerTransform.position.x - transform.position.x) < 0? -1 : 0 * tileRad, (playerTransform.position.y - transform.position.y) > 0 ? 1 : (playerTransform.position.y - transform.position.y) < 0 ? -1 : 0 * tileRad);
    }


}
