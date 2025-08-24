using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public Transform Endposition;

    void Start()
    {
        Act();
    }
    protected virtual void Act(){
        transform.DOMove(Endposition.position, 2).SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Yoyo);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
