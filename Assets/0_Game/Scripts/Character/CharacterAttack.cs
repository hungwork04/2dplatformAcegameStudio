using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject bullet;
    //[SerializeField]private BulletPooling bulPool;
    public Transform shootPos;
    [SerializeField] private float bulletScale = 0.35f;
    public void shoot()
    {
        if (bullet == null || shootPos == null)
        {
            Debug.Log("Thiếu Ref");
            return;
        }
        //var newBul = bulPool.Get(bulPool.bulletpool);
        var newBul = PoolManager.instance.Get(PoolManager.instance.bulletpool);
        newBul.transform.position = shootPos.position;
        // bật active
        CharacterCtrller body = transform.parent.GetComponentInChildren<CharacterCtrller>();
        newBul.transform.localScale = new Vector3(bulletScale, bulletScale, bulletScale);
        newBul.SetActive(true);
        newBul.GetComponent<Bullet>().setFlytVector(body.transform.localScale);

    }
}
