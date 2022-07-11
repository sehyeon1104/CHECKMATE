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
        while (true)
        {
            yield return new WaitForSeconds(Sync.Instance.tikTime);
            Move(playerTransform, blockRadius);
        }
    }

    public void Move(Transform playerTransform, float tileRad)
    {
      transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : (playerTransform.position.x - transform.position.x) < 0? -1 : 0 * tileRad, (playerTransform.position.y - transform.position.y) > 0 ? 1 : (playerTransform.position.y - transform.position.y) < 0 ? -1 : 0 * tileRad);
    }


}
