using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KingExplosion : MonoBehaviour
{

    public Collider2D[] colliders;
    private void Start()
    {
       AddExplosition();

    }
    public float powerStart;
    public float powerEnd;



    //모든 콜라이더를 받아오고 
    //콜라이더에다가 랜덤한 방향으로 폭발하게 만들어줌
    public void AddExplosition()
    {
        foreach(Collider2D col in colliders)
        {
            float ranX = Random.Range(-1f , 1f);
            float ranY = Random.Range(-1f, 1f);

            Vector2 explosionVec = new Vector3(ranX, ranY, 0f);

            float power = Random.Range(powerStart, powerEnd);
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(explosionVec * power, ForceMode2D.Impulse);

            //랜덤한 방향 지정해주기
            //여기서 소리넣어주기
            //하나하나 그방향으로 폭발
        }

        Invoke("ScreenBlack", 1f);
        // 다폭발후 
        // 1.5초후에는 화면이 까매지고, 체크메이트라는 글자가 뜨게 만든다
        // 체크메이트가 다뜨면
        //다시하기와 나가기가 뜨게한다.
    }

    void ScreenBlack()
    {
        //화면 블랙되는거 
        //다시 시작되게

        CheckMateGameOver.Instance.GameObjectSet(true);

        //일드리턴
        Loader.Load(Loader.Scene.Seunghun);

    }


}
