using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private float Duration = 3f;
    
    public Transform PosB;
    public Animator ani;
    public Tween tween;
    private void Awake()
    {
        if(ani== null)
        ani = GetComponent<Animator>();
    }
    private void Start()
    {
        MoveLoop(PosB);
    }

    public void MoveLoop(Transform Pos)
    {
        ani.Play("Saw_On");
        tween = transform.DOMove(Pos.position, Duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

}
