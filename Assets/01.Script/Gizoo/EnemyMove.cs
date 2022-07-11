using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMove
{
    public void Move(Transform playerTransform, float tileRad);
}

public class PawnMove : MonoBehaviour,IEnemyMove
{
    public void Move(Transform playerTransform, float tileRad)
    {
        //if(Mathf.Abs(playerTransform.position.x-transform.position.x) >= tileRad && Mathf.Abs(playerTransform.position.y - transform.position.y) >= tileRad)
        //{
        //    transform.position += (playerTransform.position - transform.position).normalized * tileRad;
        //}
        if(transform.position == playerTransform.position)
            CancelInvoke("Move");
        else
            transform.position += (playerTransform.position - transform.position).normalized * tileRad;
    }
}
public class KnightMove : MonoBehaviour, IEnemyMove
{
    public void Move(Transform playerTransform, float tileRad)
    {
        if (transform.position == playerTransform.position)
            CancelInvoke("Move");
        else
        {
            transform.position += (playerTransform.position - transform.position).normalized * tileRad;
            switch(Random.Range(0,2))
            {
                case 0:
                    transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0? 1 : -1 * tileRad, tileRad);
                    break;
                case 1:
                    transform.position += new Vector3((playerTransform.position.x - transform.position.x) > 0 ? 1 : -1 * tileRad, -tileRad);
                    break;
            }
            transform.position += (playerTransform.position - transform.position).normalized * tileRad;
        }
    }
}
//public class RookMove : MonoBehaviour, IEnemyMove
//{
//    public void Move(Transform playerTransform, float tileRad)
//    {
//        if (transform.position == playerTransform.position)
//            CancelInvoke("Move");
//    }
//}
//public class BishopMove : MonoBehaviour, IEnemyMove
//{
//    public void Move(Transform playerTransform, float tileRad)
//    {
//        if (transform.position == playerTransform.position)
//            CancelInvoke("Move");
//    }
//}
