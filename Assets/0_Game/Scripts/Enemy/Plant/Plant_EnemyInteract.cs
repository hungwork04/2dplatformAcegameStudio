using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_EnemyInteract : EnemyInteract
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        var PlayerCollision = collision.transform.parent;
        if (PlayerCollision.CompareTag("Player"))
        {
            this.GetComponentInParent<Animator>().Play("Enemy_Hitted");
        }
    }
}
