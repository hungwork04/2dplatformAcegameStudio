using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_EnemyMovement : EnemyMovement
{
    public Rigidbody2D rb;
    //public Transform xMin;
    //public Transform xMax;

    public float force = 1;
    public float moveDir = 1;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    protected override void Start()
    {
        ani.Play("Enemy_Run");
    }
    protected override void Update()
    {
        rb.velocity=new Vector2(moveDir * force, rb.velocity.y);
        if (rb.position.x > PosB.position.x && moveDir>0)
        {
            moveDir *= -1;
        }
        else if (rb.position.x < PosA.position.x && moveDir<0)
        {
            moveDir *= -1;
        }
        var localScale = transform.localScale;
        if (moveDir > 0 && localScale.x<0)
        {
            transform.localScale = new Vector3(localScale.x*-1, localScale.y, localScale.z);
        }
        else if(moveDir < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(localScale.x*-1, localScale.y, localScale.z);
        }
    }

}
