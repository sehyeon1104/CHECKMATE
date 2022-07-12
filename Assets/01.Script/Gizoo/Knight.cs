using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    private Transform playerTransform;
    private float blockRadius = 1f;
    private int dirType;

    [SerializeField] private Sprite[] sprites;

    private void Start()
    {
        dirType = Random.Range(0, 2);
        playerTransform = GameObject.FindWithTag("Player").transform;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[dirType];
        StartCoroutine(KnightM());
    }

    private IEnumerator KnightM()
    {
        while (transform.position != playerTransform.position)
        {
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
            transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : (playerTransform.position.x - transform.position.x) < 0 ? -1 : 0 * blockRadius, (playerTransform.position.y - transform.position.y) > 0 ? 1 : (playerTransform.position.y - transform.position.y) < 0 ? -1 : 0 * blockRadius);
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
            switch (dirType)
            {
                case 0:
                    if(playerTransform.position.y - transform.position.y == 0)
                        transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : -1 * blockRadius, blockRadius);
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
