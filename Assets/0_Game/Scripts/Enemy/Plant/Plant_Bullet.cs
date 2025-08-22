using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plant_Bullet : Bullet
{
    public Plant_EnemyAttack atk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var GO = collision?.transform.gameObject;
        //Debug.Log(this.transform.gam);
        if (GO.transform.parent.tag=="Player"|| GO.tag == "Ground")
        {
            Debug.Log(GO.name);

            var playerCtrl = GO.GetComponentInParent<CharacterCtrller>();
            Debug.Log(playerCtrl);
            if (playerCtrl != null)
            {
                if(atk != null)
                {
                    atk.Effect(playerCtrl);
                    playerCtrl.ani.SetTrigger("IsHitted");
                }
            }
            PoolManager.instance.Plant_bulletpool.Return(this.gameObject);
            
        }
    }
}
