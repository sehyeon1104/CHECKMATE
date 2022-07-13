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



    //��� �ݶ��̴��� �޾ƿ��� 
    //�ݶ��̴����ٰ� ������ �������� �����ϰ� �������
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

            //������ ���� �������ֱ�
            //���⼭ �Ҹ��־��ֱ�
            //�ϳ��ϳ� �׹������� ����
        }

        Invoke("ScreenBlack", 1f);
        // �������� 
        // 1.5���Ŀ��� ȭ���� �������, üũ����Ʈ��� ���ڰ� �߰� �����
        // üũ����Ʈ�� �ٶ߸�
        //�ٽ��ϱ�� �����Ⱑ �߰��Ѵ�.
    }

    void ScreenBlack()
    {
        //ȭ�� ���Ǵ°� 
        //�ٽ� ���۵ǰ�

        CheckMateGameOver.Instance.GameObjectSet(true);

        //�ϵ帮��
        Loader.Load(Loader.Scene.Seunghun);

    }


}
