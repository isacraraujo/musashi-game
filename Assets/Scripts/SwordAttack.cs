using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float damage = 3;
    Vector2 rightAttackOffset;
    public float knockbackForce = 15f;
    public float swordDamage = 1f;

    private void Start() {
        rightAttackOffset = transform.position;
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        IDamageble damagebleObject = collider.GetComponent<IDamageble>();

        if(damagebleObject != null) {
            Vector3 parentPosition = transform.parent.position;  

            Vector2 direction = (Vector2) (collider.gameObject.transform.position - parentPosition).normalized;
            
            Vector2 knockback = direction * knockbackForce;

            damagebleObject.OnHit(swordDamage, knockback);
        }
    }
}
