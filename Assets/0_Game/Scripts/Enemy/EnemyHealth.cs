using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{

    public override void TakeDamage(int damage)
    {
        if (curHeart <= damage)
        {
            curHeart = 0;
            //Debug.Log(this.transform.parent?.gameObject + " - DEAD");
            OnDead();
            return;
        }
        curHeart -= damage;
    }
    protected virtual void OnDead()
    {
        EnemyMovement move = GetComponent<EnemyMovement>();
        move.StopAllCoroutines();
        move.tween.Kill();
        move.ani.Play("Enemy_Hitted");
        StartCoroutine(WaitBeforeDisable(0.2f));
    }
    public IEnumerator WaitBeforeDisable(float time)
    {
        yield return new WaitForSeconds(time);
        transform.gameObject.SetActive(false);

    }
}
