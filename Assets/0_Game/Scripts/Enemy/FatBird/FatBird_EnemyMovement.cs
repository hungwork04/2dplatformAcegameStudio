using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBird_EnemyMovement : EnemyMovement
{
    public GameObject Cup;
    public FatBird_Area area;

    private void OnEnable()
    {
        Cup.SetActive(false);
    }
    public override void MoveLoop(Transform Pos)
    {
        curPos = Pos;
        ani.Play("Enemy_Fly");
        if (tween == null)
        {
            Debug.Log("Moveloop");
            tween = transform.DOMove(Pos.position, EneTime).SetEase(Ease.Linear).OnComplete(() =>
            {
                StartCoroutine(wait(stopTime, curPos));
            });
        }
        //Sequence sq = DOTween.Sequence();
        //sq.Append(transform.DOMove(PosA.position, EneTime).SetEase(Ease.Linear));/*.AppendInterval(EneTime);*/
        //sq.Append(transform.DOMove(PosB.position, EneTime).SetEase(Ease.Linear));
        //sq.SetLoops(-1);

    }


    public override IEnumerator wait(float stopTime, Transform Pos)
    {
        yield return new WaitForSeconds(stopTime);
        Debug.Log("wait to back move loop");
        tween.Kill();
        tween = null;
        if (Pos == PosA)
            MoveLoop(PosB);
        else MoveLoop(PosA);
        //re - optimize
    }
    private void OnDisable()
    {
        try
        {
            Cup.SetActive(true);
        }
        catch (System.Exception)
        {
            return;
        }
    }
}
