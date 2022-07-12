using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookChess : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    private void OnEnable()
=======
<<<<<<< HEAD
    public Transform Player;
    private void OnEnable()
=======
    private Transform playerTransform;
    private float blockRadius = 1f;

    private void Start()
>>>>>>> 8c7228c07f5a1705709f9a18458f6c5025638e75
>>>>>>> ace609edff14e927174ec35c09eba4abd78deee7
=======
    private void OnEnable()
>>>>>>> parent of 8c7228c (스폰 시스템 조정)
    {
        transform.DOMove(new Vector2(GameManager.Instance.Player.position.x, GameManager.Instance.Player.position.y), 1f).SetEase(Ease.OutQuart);
    }
}
