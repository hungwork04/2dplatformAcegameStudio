using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FatBird_Area : MonoBehaviour
{
    FatBird_EnemyMovement fatbirdMove;
    Transform target =null;
    private void Awake()
    {
        fatbirdMove = GetComponentInParent<FatBird_EnemyMovement>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var PlayerCollision = collision.transform.parent;
        if (PlayerCollision.CompareTag("Player")&& !target)
        {
            target = PlayerCollision;
            fatbirdMove.tween.Kill();
            fatbirdMove.tween= transform.parent.DOMove(PlayerCollision.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.parent.DOMove(fatbirdMove.curPos.position, 1f).SetEase(Ease.Linear);
                StartCoroutine(wait(1));
            });
        }
    }
    public IEnumerator wait(float stopTime)
    {
        yield return new WaitForSeconds(stopTime);
        if (fatbirdMove.curPos == fatbirdMove.PosA)
            fatbirdMove.MoveLoop(fatbirdMove.PosB);
        else fatbirdMove.MoveLoop(fatbirdMove.PosA);
        target = null;

        //re - optimize
    }
}
