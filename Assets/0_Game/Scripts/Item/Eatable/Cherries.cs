using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherries : EatItem
{
    public override void Eat()
    {
        GameManager.instance.Score += 3;
        base.Eat();
    }

}