using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private float moveSpeed = 6f;
    public CharacterController ctrl;
    public Vector2 moveInput;
    private void LateUpdate()
    {
        //moveInput.x = Input.GetAxisRaw("Horizontal");
        if (ctrl.state.airState != CharacterState.AIR_STATE.NONE)// 
        {
            ctrl.ani.SetBool("IsDoubleJump", ctrl.state.airState == CharacterState.AIR_STATE.DOUBLE_JUMP);
        }
        //if (ctrl.rb.velocity.y!=0)// sai logic chạy về và chưa kịp check 0 
        //{
            ctrl.ani.SetFloat("yVelocity", ctrl.rb.velocity.y);
            if (ctrl.rb.velocity.y < -0.1f)
            {
                ctrl.state.airState = CharacterState.AIR_STATE.FALL;
            }
        //}
        ctrl.ani.SetFloat("xVelocity", Mathf.Abs(moveInput.x));

        Flip();
    }
    public void setXInput(int x)
    {
        moveInput.x = x;
    }
    private void Awake()
    {
        if (ctrl == null)
        {
            ctrl = transform.parent.GetComponentInChildren<CharacterController>();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        ctrl.rb.velocity = new Vector2(moveInput.x * moveSpeed, ctrl.rb.velocity.y);
    }
    public void Jump()
    {
        CharacterState thisState = ctrl.state;
        if (!thisState.CanJump && !thisState.CanDoubleJump)
            return;
        //if (thisState.CanJump|| thisState.CanDoubleJump)

        ctrl.rb.velocity = new Vector2(ctrl.rb.velocity.x, jumpForce);
        if (thisState.CanJump)
        {
            thisState.airState = CharacterState.AIR_STATE.JUMP;
            thisState.CanJump = false;
        }
        else if (thisState.CanDoubleJump)
        {
            thisState.airState = CharacterState.AIR_STATE.DOUBLE_JUMP;
            thisState.CanDoubleJump = false;

        }
        if ((thisState.airState == CharacterState.AIR_STATE.JUMP || thisState.airState == CharacterState.AIR_STATE.FALL) && thisState.CanJump == false)
        {
            thisState.CanDoubleJump = true;
        }


    }
    private void Flip()
    {
        var localScale = ctrl.transform.localScale;
        if (moveInput.x > 0 && localScale.x < 0)
        {
            var newX = localScale.x * -1;
            ctrl.transform.localScale = new Vector3(newX, localScale.y, localScale.z);
        }
        else if (moveInput.x < 0 && localScale.x > 0)
        {
            var newX = ctrl.transform.localScale.x * -1;
            ctrl.transform.localScale = new Vector3(newX, localScale.y, localScale.z);
        }
    }

}
