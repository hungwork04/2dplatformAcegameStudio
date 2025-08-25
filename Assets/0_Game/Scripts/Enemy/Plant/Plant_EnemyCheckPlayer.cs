using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plant_EnemyCheckPlayer : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision?.transform.parent.gameObject;

        if (player.tag == "Player")
        {
            //Debug.Log("start");
            InvokeRepeating("repeataction", 0.2f, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision?.transform.parent.gameObject;

        if (player.tag == "Player")
        {
            //Debug.Log("End");
            CancelInvoke("repeataction");
        }
    }
    public void repeataction()
    {
        GetComponentInParent<Animator>().Play("Enemy_Attack");
    }
}
