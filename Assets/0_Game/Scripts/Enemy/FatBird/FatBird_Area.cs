using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FatBird_Area : MonoBehaviour
{
    FatBird_EnemyMovement fatbirdMove;
    public Transform target =null;
    private void Awake()
    {
        fatbirdMove = GetComponentInParent<FatBird_EnemyMovement>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var PlayerCollision = collision.transform.parent;
        if (PlayerCollision.CompareTag("Player")&& target ==null)
        {
            target = PlayerCollision;
            fatbirdMove.tween.Kill();
            fatbirdMove.tween= null;
            //fatbirdMove.tween= transform.parent.DOMove(PlayerCollision.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
            //{
            //    GetComponentInParent<Animator>().SetTrigger("IsGrounded");
            //    transform.parent.DOMove(fatbirdMove.curPos.position, 3f).SetEase(Ease.Linear).OnComplete(()=>{
            //        if(gameObject.activeInHierarchy)
            //        StartCoroutine(wait(1));
            //    });
            //});
            GetComponentInParent<Animator>().SetTrigger("IsFall");
            Sequence sq = DOTween.Sequence();
            sq.Append(transform.parent.DOMove(PlayerCollision.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                GetComponentInParent<Animator>().SetTrigger("IsGrounded");
                Debug.Log("Ground");
            }));
            sq.Append(transform.parent.DOMove(fatbirdMove.curPos.position, 3f).SetEase(Ease.Linear)).OnComplete(() => {
                if (gameObject.activeInHierarchy)
                    StartCoroutine(wait(1));
            });
        }
    }
    
    public IEnumerator wait(float stopTime)
    {
        yield return new WaitForSeconds(stopTime);
        GetComponentInParent<Animator>().Play("Enemy_Fly");
        if (fatbirdMove.curPos == fatbirdMove.PosA)
            fatbirdMove.MoveLoop(fatbirdMove.PosB);
        else fatbirdMove.MoveLoop(fatbirdMove.PosA);
        target = null;

        //re - optimize
    }
    private void OnDisable()
    {
        fatbirdMove.tween.Kill();
        StopAllCoroutines();
    }
}
