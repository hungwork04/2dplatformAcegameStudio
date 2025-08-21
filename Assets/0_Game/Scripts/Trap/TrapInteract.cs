using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapInteract : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        var player = collision.transform.gameObject;

        if (player.CompareTag("Player"))
        {
            player.transform.position =GameManager.instance.StartPoint.position;
            Debug.Log(collision.collider.gameObject.name);
        }
    }
}
