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
    public Vector3 originLocalscale;
    public float originMovespeed;
    public float originJumpForce;
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
        originLocalscale = transform.parent.localScale;
        originJumpForce = characterMovement.jumpForce;
        originMovespeed = characterMovement.moveSpeed;
        OnUpdateCharacterScaleByMoney();
    }
    private void OnEnable()
    {
        ObserverManager.OnUpdateScore += OnUpdateCharacterScaleByMoney;
    }
    private void OnDisable()
    {
        ObserverManager.OnUpdateScore -= OnUpdateCharacterScaleByMoney;
    }
    public void OnUpdateCharacterScaleByMoney()
    {

        int dex = (int)(DataController.Money / 10);
        float scale = 1f + dex * 0.15f;

        scale = Mathf.Min(scale, 1.5f);
        transform.parent.localScale = new Vector3(
            originLocalscale.x * scale,
            originLocalscale.y * scale,
            originLocalscale.z * scale
        );
        characterMovement.jumpForce  = Mathf.Min(originJumpForce * scale,6*1.5f);
        characterMovement.moveSpeed  = Mathf.Min(originMovespeed * scale, 6 * 1.5f);

    }

}
