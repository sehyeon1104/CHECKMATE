using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefab;
    float randomY;
    float randomX;
    float xPos = 0;
    float yPos = 0;
    int enemyType = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(5f);
            while (new Vector3(xPos, yPos) == Vector3.zero)
            {
                randomX = Random.Range(0, 3);
                switch (randomX)
                {
                    case 0:
                        xPos = 0;
                        break;
                        xPos = 2;
                    case 1:
                        xPos = -2;
                        break;
                    case 2:
                        break;
                }
                randomY = Random.Range(0, 3);
                switch (randomY)
                {
                    case 0:
                        yPos = 0;
                        break;
                    case 1:
                        yPos = 2;
                        break;
                    case 2:
                        yPos = -2;
                        break;
                }
            }
            if(xPos != 0 && yPos != 0)
            {
                enemyType = 0;
            }
            else
            {
                enemyType = Random.Range(0, 2);
            }
            Instantiate(enemyPrefab[enemyType], new Vector3(xPos, yPos), transform.rotation);
            xPos = 0;
            yPos = 0;
        }
    }
}
