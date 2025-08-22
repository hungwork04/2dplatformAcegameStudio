using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)//Damagable Side
    {
        var PlayerCollision = collision.transform.parent;
        if (PlayerCollision.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject);
            this.GetComponentInParent<EnemyMovement>().IsHitted = true;
            this.GetComponentInParent<Animator>().Play("Enemy_Hitted");
        }

    }
}
