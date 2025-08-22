using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("cc");

        var playerGO = collision.transform?.parent.gameObject;
        if (playerGO.tag == "Player")
        {
            //Debug.Log("cc");
            var playerRigid = playerGO.GetComponent<Rigidbody2D>();
            playerRigid.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
            GetComponent<Animator>().SetTrigger("Hitted");
        }
    }
}
