using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemyDamageableCharacter : MonoBehaviour, IDamageble {
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    public float _health = 1;
    public float damage = 1;

    public float Health {
        set {
            if (value < _health) {
                HitDamage();
            }

            _health = value;

            if (_health <= 0) {
                Defeated();
                Targetable = false;
                rb.simulated = false;
            }
        }
        get {
            return _health;
        }
    }

    public bool Targetable {
        get {
            return _targetable;
        }
        set { 
            _targetable = value;            
            physicsCollider.enabled = value;
        }
    }

    public bool _targetable = true;

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }
    public void Defeated() {
        animator.SetTrigger("Defeated");
    }
    public void HitDamage() {
        animator.SetTrigger("HitDamage");
    }
    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        // Aplicar força no inimigo
        rb.AddForce(knockback); 
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }
}
