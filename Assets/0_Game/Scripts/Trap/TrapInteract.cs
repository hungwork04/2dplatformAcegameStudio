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
            player.SetActive(false);
            DataController.Money =Mathf.FloorToInt(0.7f * DataController.Money);
            Debug.Log(DataController.Money);
            ObserverManager.OnPlayerEndGame?.Invoke("LOSE");
            //Debug.Log(collision.collider.gameObject.name);
        }
    }
}
