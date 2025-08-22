using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractItem : MonoBehaviour, IInteract
{
    public void Interact()
    {
        Animator ani = GetComponent<Animator>();
        ani.SetTrigger("Hitted");

       
    }
}
