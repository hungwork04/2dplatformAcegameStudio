using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    [SerializeField]private int EatablelayerIndex;
    [SerializeField]private int InteractablelayerIndex;
    [SerializeField]private int EnemylayerIndex;
    [SerializeField]private string DamageableTag;
    CharacterCtrller ctrl;
    private void Awake()
    {
        ctrl= GetComponent<CharacterCtrller>();
        EatablelayerIndex = LayerMask.NameToLayer("EatableItem");
        InteractablelayerIndex = LayerMask.NameToLayer("InteractableItem");
        EnemylayerIndex = LayerMask.NameToLayer("Enemy");
        DamageableTag = "Damagable";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionGO = collision.gameObject;
        if (collisionGO.layer == EatablelayerIndex)
        {
            collision.GetComponent<IEatable>().Eat();
        }
        else if (collisionGO.layer == InteractablelayerIndex)
        {
            var refer = collisionGO.GetComponent<IInteract>();
            refer.Interact();

            var hit = Physics2D.Raycast(collisionGO.transform.position, Vector2.up, 30, EnemylayerIndex);
            Debug.DrawRay(collisionGO.transform.position, Vector2.up * 30, Color.red);
            if (hit.collider == null) return;
            var EnenmyGO = hit.collider.transform.parent.gameObject;
            Debug.Log(EnenmyGO.name);
            if (EnenmyGO.layer == EnemylayerIndex)
            {
                if (EnenmyGO.GetComponent<EnemyMovement>() != null)
                {
                    EnenmyGO.GetComponent<EnemyMovement>().IsHitted = true;
                }
                EnenmyGO.GetComponent<Animator>().Play("Enemy_Hitted");
                EnenmyGO.GetComponent<EnemyHealth>().TakeDamage(2);
            }
        }
        else if (collisionGO.CompareTag(DamageableTag))
        {
            collisionGO.GetComponentInParent<EnemyHealth>().TakeDamage(2);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionGO = collision.gameObject;
        if (collisionGO.layer == EnemylayerIndex)
        {
            GetComponent<Animator>().SetTrigger("IsHitted");

        }
    }


    IEnumerator IgnoreColliderTemp(Collider2D other)
    {
        Collider2D mycol = this.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(mycol, other, true);
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreCollision(mycol, other, false);

    }
}
