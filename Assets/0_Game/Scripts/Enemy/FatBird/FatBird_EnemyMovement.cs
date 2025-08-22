using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBird_EnemyMovement : EnemyMovement
{
    public override void MoveLoop(Transform Pos)
    {
        curPos = Pos;
        ani.Play("Enemy_Fly");
        tween = transform.DOMove(Pos.position, EneTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            StartCoroutine(wait(stopTime, Pos));
        });
    }
    public override IEnumerator wait(float stopTime, Transform Pos)
    {
        yield return new WaitForSeconds(stopTime);
        if (Pos == PosA)
            MoveLoop(PosB);
        else MoveLoop(PosA);
        //re - optimize
    }
}
