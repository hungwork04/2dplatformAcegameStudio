using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRb;
    public float flySpeed = 14f;
    //public int bounceCount = 5;
    //float coolDown = 3;
    [SerializeField]private Vector3 thisVec;
    private void Awake()
    {
        if (bulletRb == null)
            bulletRb= GetComponent<Rigidbody2D>();
    }
    //private void OnEnable()
    //{
    //    bounceCount = 5;
    //}
    public void setFlytVector(Vector3 bodyvec)
    {
        if (bodyvec.x > 0)
        {
            thisVec = new Vector2(1,0);
        }
        else thisVec = new Vector2(-1, 0); ;
        bulletRb.velocity = thisVec * flySpeed;

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Ground")
    //    {
    //        Debug.Log("-1");
    //        if (bounceCount - 1 <= 0)
    //        {
    //            PoolManager.instance.bulletpool.Return(this.gameObject);
    //            return;
    //        }
    //        bounceCount--;

    //    }
    //}
    //IEnumerator CoolDownToDestroy()
    //{
    //    yield return new WaitForSeconds(coolDown);
    //    PoolManager.instance.bulletpool.Return(this.gameObject);
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("-1");
            PoolManager.instance.bulletpool.Return(this.gameObject);
            collision.GetComponent<Health>().TakeDamage(2);
        }
        else if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("-1");
            PoolManager.instance.bulletpool.Return(this.gameObject);
        }
    }
}
