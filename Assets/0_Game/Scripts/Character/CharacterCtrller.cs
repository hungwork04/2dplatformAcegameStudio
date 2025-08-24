using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrller : MonoBehaviour
{
    public Movement characterMovement;
    public Health characterHealth;
    public Animator ani;
    public Rigidbody2D rb;
    public CharacterState state;
    private void Awake()
    {
        var parentTrans = transform.parent;
        if(characterMovement==null)
            characterMovement = parentTrans.GetComponentInChildren<Movement>();
        if(characterHealth==null)
            characterHealth = parentTrans.GetComponentInChildren<Health>();
        if(ani==null)
            ani= GetComponent<Animator>();
        if (rb == null)
            rb = GetComponentInParent<Rigidbody2D>();
        if(state==null)
            state = parentTrans.GetComponentInChildren<CharacterState>();
    }
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = PlayerManager.player.Sprite;
        ani.runtimeAnimatorController = PlayerManager.player.animatorController;
    }

}
