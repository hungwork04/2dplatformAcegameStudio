using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Plant_EnemyAttack : EnemyAttack
{
    public GameObject bullet;
    public Transform shootingPos;
    Coroutine coroutine;
    CharacterCtrller characterCtrller;
    public override void Attack()
    {
        shoot();
    }

    public void shoot()
    {
        if (bullet == null || shootingPos == null)
        {
            Debug.Log("Thiếu Ref");
            return;
        }
        var newBul = PoolManager.instance.Get(PoolManager.instance.Plant_bulletpool);
        newBul.transform.position = shootingPos.position;
        // bật active
        newBul.transform.localScale = new Vector3(5, 5, 5);
        var refer = newBul.GetComponent<Plant_Bullet>();
        refer.atk = this;
        newBul.SetActive(true);
        refer.setFlytVector(-transform.localScale);
    }


    public void Effect(CharacterCtrller character)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        Debug.Log("Here");
        Plant_EnemyAttack atk = this.GetComponent<Plant_EnemyAttack>();
        coroutine = StartCoroutine(SlowDown(character));
    }
    IEnumerator SlowDown(CharacterCtrller character)
    {
        var originSpeed = character.characterMovement.originSpeed;
        characterCtrller = character;
        if (character.characterMovement.moveSpeed > 0)
        {
            character.characterMovement.moveSpeed -= 1;
        }
        yield return new WaitForSeconds(2);
        Debug.Log("Here");
        character.characterMovement.moveSpeed = originSpeed;
    }
    private void OnDisable()
    {
        if (characterCtrller != null)
        {
            var originSpeed = characterCtrller.characterMovement.originSpeed;
            characterCtrller.characterMovement.moveSpeed = originSpeed;
        }

    }
}
