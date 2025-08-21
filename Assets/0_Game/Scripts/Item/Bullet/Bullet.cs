using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRb;
    public float flySpeed = 14f;
    [SerializeField]private Vector3 thisVec;
    private void Awake()
    {
        if (bulletRb == null)
            bulletRb= GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        bulletRb.velocity = thisVec * flySpeed;
    }
    public void setFlytVector(Vector3 bodyvec)
    {
        if (bodyvec.x > 0)
        {
            thisVec=  Vector3.right;
        }
        else thisVec = Vector3.left;
    }
}
