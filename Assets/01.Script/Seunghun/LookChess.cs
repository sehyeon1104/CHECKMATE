using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookChess : MonoBehaviour
{
    private Transform playerTransform;
    private float blockRadius = 1f;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        Move(playerTransform, blockRadius);
    }

    private void Update()
    {
        if(transform.position == playerTransform.position)
        {
            Destroy(gameObject, Sync_Gijoo.Instance.tikTime);
        }
    }

    public void Move(Transform playerTransform, float tileRad)
    {
        transform.DOMove(transform.position + new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 4 : (playerTransform.position.x - transform.position.x) < 0 ? -4 : 0 * tileRad, (playerTransform.position.y - transform.position.y) > 0 ? 4 : (playerTransform.position.y - transform.position.y) < 0 ? -4 : 0 * tileRad),Sync_Gijoo.Instance.tikTime);
    }


}
