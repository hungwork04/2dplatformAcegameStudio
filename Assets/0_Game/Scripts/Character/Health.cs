using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected virtual int maxHeart { get; } = 10;

    [SerializeField] protected int curHeart;
    private void Start()
    {
        curHeart = maxHeart;
    }
    public virtual void TakeDamage(int damage)//Interface IDamagable
    {
        if (curHeart <= 0)
        {
            Debug.Log(this.transform.parent?.gameObject + " - DEAD");
            return;
        }
        curHeart -= damage;
    }
}
