using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotationObject : MovableObject
{
    public float delayTime;
    protected override void Act(){
        transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)
         .SetEase(Ease.Linear)
         .SetDelay(delayTime)
         .SetLoops(-1, LoopType.Restart);
    }
}
