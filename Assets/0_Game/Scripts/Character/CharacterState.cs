using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public bool IsJump;
    public bool IsFall;
    public bool CanJump;
    public bool CanDoubleJump;
    public AIR_STATE airState = AIR_STATE.NONE;
    public enum AIR_STATE
    {
        NONE,
        JUMP,
        FALL,
        DOUBLE_JUMP
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" && !CanJump)
        {
            CanJump = true;
            airState = AIR_STATE.NONE;
        }
    }
}
