using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warningSign : ChessMal
{

    public GameObject LookObj;
    public SpriteRenderer spriteR;
    private void OnEnable()
    {
        StartCoroutine(Ienum());
    }

    public int beat;
    IEnumerator Ienum()
    {
        for(int i = 0; i < beat; i++)
        {
            spriteR.color = Color.black;
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);
            spriteR.color = Color.white;
            yield return new WaitForSeconds(Sync_Gijoo.Instance.tikTime);

        }

        GameObject obj = Instantiate(LookObj, transform.position, Quaternion.identity);


        IArrow arr = obj.GetComponent<IArrow>();

        //�׷����� ��ȣ�� �װ� ���ݾ�?
        if (arr != null)
        {

            Debug.Log("�ȵǴ� �ǰ�");
            arr.ArrowCopySW(arrow);
        }
        gameObject.SetActive(false);

    }

    public override void ArrowCopySW(ChessSpawnArrowEnum.ChessArrow chessArrow)
    {
        base.ArrowCopySW(chessArrow);
    }

    public override ChessSpawnArrowEnum.ChessArrow GetArrowState()
    {
        return base.GetArrowState();
    }
}
