using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Animator animator;
    public float _health = 1;

    public float Health {
        set {
            if (value < _health) {
                HitDamage();
            }

            _health = value;

            if (_health <= 0) {
                Defeated();
            }
        }
        get {
            return _health;
        }
    }

    private void Start() {
        animator = GetComponent<Animator>();
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
}
