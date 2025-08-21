using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] protected override int maxHeart { get; } =5;

    public override void TakeDamage(int damage)
    {
        if (curHeart <= damage)
        {
            curHeart = 0;
            Debug.Log(this.transform.parent?.gameObject + " - DEAD");
            OnDead();
            return;
        }
        curHeart -= damage;
    }
    private void OnDead()
    {
        EnemyMovement move = GetComponent<EnemyMovement>();
        move.StopAllCoroutines();
        move.tween.Kill();
        move.ani.Play("Enemy_Hitted");
        StartCoroutine(WaitBeforeDisable(0.2f));
    }
    IEnumerator WaitBeforeDisable(float time)
    {
        yield return new WaitForSeconds(time);
        transform.gameObject.SetActive(false);

    }
}
