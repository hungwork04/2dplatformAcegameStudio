using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_EnemyMovement : EnemyMovement
{
    public override IEnumerator wait(float stopTime, Transform Pos)
    {
        EneFlip();
        yield return new WaitForSeconds(stopTime);
        if (Pos == PosA)
            MoveLoop(PosB);
        else MoveLoop(PosA);
        //re - optimize
    }
}
