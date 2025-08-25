using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractItem : MonoBehaviour, IInteract
{
    public void Interact()
    {
        Animator ani = GetComponent<Animator>();
        ani.SetTrigger("Hitted");
        BoxHealth health = GetComponent<BoxHealth>();
        if (health != null)
        {
            Debug.Log("here");
            health.TakeDamage(2);
        }

       
    }
}
