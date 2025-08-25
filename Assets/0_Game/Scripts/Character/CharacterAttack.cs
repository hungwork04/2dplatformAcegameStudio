using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject bullet;
    //[SerializeField]private BulletPooling bulPool;
    public Transform shootPos;
    [SerializeField] private float bulletScale = 0.35f;
    public bool isWaiting;
    [SerializeField]private float CoolDownTime = 0.5f;
    float curCooldown;
    private void Start()
    {
        curCooldown = CoolDownTime;
    }
    private void Update()
    {
        if (isWaiting)
        {
            curCooldown -= Time.deltaTime;
            if (curCooldown <= 0)
            {
                isWaiting = false;
                curCooldown = CoolDownTime;
            }
        }
    }
    public void shoot()
    {
        if (bullet == null || shootPos == null)
        {
            Debug.Log("Thiếu Ref");
            return;
        }
        if (isWaiting) return;
        Debug.Log("spawn bullet");
        var newBul = PoolManager.instance.Get(PoolManager.instance.bulletpool);
        newBul.transform.position = shootPos.position;
        CharacterCtrller body = transform.parent.GetComponentInChildren<CharacterCtrller>();
        newBul.transform.localScale = new Vector3(bulletScale, bulletScale, bulletScale);
        newBul.SetActive(true);
        newBul.GetComponent<Bullet>().setFlytVector(body.transform.localScale);
        isWaiting = true;

    }
}
