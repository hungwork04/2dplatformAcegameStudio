using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanInteract : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Animator>().SetBool("IsOn",true);
    }
    private  void OnTriggerEnter2D(Collider2D collision)
    {
        var playerGO= collision.transform.parent.gameObject;
        if(playerGO.tag == "Player")
        {
            var playerRigid = playerGO.GetComponent<Rigidbody2D>();
            playerRigid.gravityScale = 0.3f;
            playerRigid.AddForce(Vector2.up * 7.5f,ForceMode2D.Impulse);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var playerGO = collision.transform.parent.gameObject;
        if (playerGO.tag == "Player")
        {
            var playerRigid = playerGO.GetComponent<Rigidbody2D>();
            playerRigid.gravityScale = 1f;
        }
    }
}
