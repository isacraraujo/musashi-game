using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float damage = 1;
    public float knockbackForce = 300f;
    public DetectionZone detectionZone;
    public float moveSpeed = 500f;
    Rigidbody2D rb;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (detectionZone.detectedObjs.Count > 0) {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D col) {
        Collider2D collider = col.collider;
        IDamageble damageble = col.collider.GetComponent<IDamageble>();

        if (damageble != null) {           
            Vector2 direction = (collider.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;
            damageble.OnHit(damage, knockback);
        }
    }

}
