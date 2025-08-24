using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : Health
{
    public override void TakeDamage(int damage)
    {
        if (curHeart <= 0)
        {
            Debug.Log(this.transform.parent?.gameObject + " - DEAD");
            this.transform.parent.gameObject.SetActive(false);
            ObserverManager.OnPlayerDead?.Invoke("LOSE");
            return;
        }
        curHeart -= damage;
    }
}
