using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItem : MonoBehaviour,IEatable
{
    public virtual void Eat()
    {
        Debug.Log(this.gameObject.name);
        this.gameObject.SetActive(false);
        ObserverManager.OnUpdateScore?.Invoke();
    }
}
