using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : Health
{
    public override void TakeDamage(int damage)//Interface IDamagable
    {
        if (curHeart-damage <= 0)
        {
            Debug.Log(this.transform.parent?.gameObject + " - DEAD");
            this.gameObject.SetActive(false);
            return;
        }
        curHeart -= damage;
    }
}
