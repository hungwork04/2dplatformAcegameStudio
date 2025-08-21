using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Movement characterMovement;
    public Health characterHealth;
    public Animator ani;
    public Rigidbody2D rb;
    public CharacterState state;
    private void Awake()
    {
        if(characterMovement==null)
            characterMovement = transform.parent.GetComponentInChildren<Movement>();
        if(characterHealth==null)
            characterHealth = transform.parent.GetComponentInChildren<Health>();
        if(ani==null)
            ani= GetComponent<Animator>();
        if (rb == null)
            rb = GetComponentInParent<Rigidbody2D>();
        if(state==null)
            state = GetComponent<CharacterState>();
    }
    private void Start()
    {
        SelectCharacterManager chaSelected = FindAnyObjectByType<SelectCharacterManager>();
        GetComponent<SpriteRenderer>().sprite = chaSelected.chas[SelectCharacterManager.chooseIndex].Sprite;
        ani.runtimeAnimatorController = chaSelected.chas[SelectCharacterManager.chooseIndex].animatorController;
    }
}
