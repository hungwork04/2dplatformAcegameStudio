using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : EatItem
{
    public override void Eat()
    {
        GameManager.instance.Level += 1;
        base.Eat();
    }

}
