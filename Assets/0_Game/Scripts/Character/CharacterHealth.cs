using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : Health
{
    public override void TakeDamage(int damage)
    {
        if (curHeart-damage <= 0)
        {
            Debug.Log(this.transform.parent?.gameObject + " - DEAD");
            this.transform.parent.gameObject.SetActive(false);
            DataController.Money = Mathf.FloorToInt(0.7f * DataController.Money);
            //Debug.Log(DataController.Money);

            ObserverManager.OnPlayerEndGame?.Invoke("LOSE");
            return;
        }
        curHeart -= damage;
        if(DataController.Money -3 <=0)
        {
            DataController.Money = 0;
        }
        else
        {
            DataController.Money -= 5;
        }
        ObserverManager.OnUpdateScore?.Invoke();
    }
}
