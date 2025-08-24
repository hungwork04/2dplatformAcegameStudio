using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float EneTime = 3f;
    [SerializeField] protected float stopTime = 0.5f;
    public Transform PosA;
    public Transform PosB;
    public Transform curPos;
    public Animator ani;

    public bool IsHitted =false;
    public Tween tween;
    private void Start()
    {
        MoveLoop(PosB);
    }
    private void Update()
    {
        if (IsHitted)
        {
            //ani.Play("Enemy_Hitted");
            tween?.Pause();
            IsHitted=false;
        }
    }
    public void EneFlip()
    {
        float newX = transform.localScale.x * -1;
        transform.localScale = new Vector3(newX, transform.localScale.y, transform.localScale.z);
    }
    public virtual void MoveLoop(Transform Pos)
    {
        curPos = Pos;
        ani.Play("Enemy_Run");
        tween= transform.DOMove(Pos.position, EneTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            StartCoroutine(wait(stopTime, Pos));
        });
    }
    public virtual IEnumerator wait(float stopTime, Transform Pos)
    {
            EneFlip();
            ani.Play("Enemy_Idle");
            yield return new WaitForSeconds(stopTime);
            if (Pos == PosA)
                MoveLoop(PosB);
            else MoveLoop(PosA);
            //re - optimize
    }
    public void ContinueTween()
    {
        tween.Play();
        ani.Play("Enemy_Run");
    }
    void OnDisable()
    {
        tween.Kill();
        StopAllCoroutines();
    }
}
