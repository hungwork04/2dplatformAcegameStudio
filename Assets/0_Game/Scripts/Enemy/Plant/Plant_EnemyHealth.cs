using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_EnemyHealth : EnemyHealth
{
    protected override void OnDead()
    {
        var ani = GetComponent<Animator>();
        ani.Play("Enemy_Hitted");
        StartCoroutine(WaitBeforeDisable(0.2f));
    }
}
