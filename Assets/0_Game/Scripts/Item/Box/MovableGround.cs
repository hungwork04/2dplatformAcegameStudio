using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovableGround : MonoBehaviour,IInteract
{
    public Transform Endposision;
    Transform Startposision;

    void Start()
    {
        Startposision= transform.parent;
    }
    public void Interact(){
        GetComponent<Collider2D>().enabled = false;
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.parent.DOMove(Endposision.position, 1).SetEase(Ease.Linear)
        .SetDelay(0.2f));
        seq.Append(transform.parent.DOMove(Startposision.position, 3).SetEase(Ease.Linear));
        seq.OnComplete(() => {
            GetComponent<Collider2D>().enabled = true;
        });
        
    }
}
