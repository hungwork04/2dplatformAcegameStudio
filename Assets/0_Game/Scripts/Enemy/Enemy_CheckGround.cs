using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_CheckGround : MonoBehaviour
{
    public Mushroom_EnemyMovement move;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (transform.parent.localScale.x > 0)
            {
                move.moveDir = 1;
            }
            else
            {
                move.moveDir = -1;
            }
            move.ani.Play("Enemy_Run");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            var hit = Physics2D.Raycast(transform.parent.position, Vector2.down, 3f);
            if (hit.collider.gameObject.tag != "Ground" && gameObject.activeInHierarchy)
            {
                move.moveDir *= 0.25f;
                move.ani.Play("Enemy_Idle");
            }
        }
    }
}
