using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Rino_EnemyMovement : EnemyMovement
{
    public override IEnumerator wait(float stopTime, Transform Pos)
    {
        //ani.Play("Enemy_HitWall");
        //yield return new WaitForSeconds(0.4f);
        ani.Play("Enemy_Idle");
        EneFlip();
        yield return new WaitForSeconds(stopTime);
        if (Pos == PosA)
            MoveLoop(PosB);
        else MoveLoop(PosA);
        //re - optimize
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ani.Play("Enemy_HitWall");
            tween.Pause();
        }
    }
    public async void DelayRedo(int ms, Action callback)
    {
        await Task.Delay(ms);
        callback?.Invoke();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Player"))
        {
            ani.Play("Enemy_HitWall");
            DelayRedo(500, () =>
            {
                tween.Kill();
                EneFlip();
                if (curPos == PosA)
                    MoveLoop(PosB);
                else MoveLoop(PosA);
            });

        }
    }
}
