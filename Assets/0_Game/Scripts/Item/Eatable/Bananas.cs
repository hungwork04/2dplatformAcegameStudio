using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananas : EatItem
{
    public override void Eat()
    {
        GameManager.instance.Money += 10;
        base.Eat();
    }

}
