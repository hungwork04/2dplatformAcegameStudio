using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//Damagable Side
    {
        if (collision.transform.parent.CompareTag("Player"))
        {
            this.GetComponentInParent<EnemyMovement>().IsHitted = true;
        }

    }
}
