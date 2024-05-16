using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    Animator animator;

    Rigidbody2D rb;

    Collider2D physicsCollider;

    public bool disableSimulation = false;

    bool isAlive = true;

    public float totalHealth = 30;

    public bool targetableObject = true;

    public float Health {
        set {
            if (value < totalHealth) {
                print("Demon got hit");
                animator.SetTrigger("hit");
            }

            print(value);
            totalHealth = value;

            if (totalHealth <= 0) {
                animator.SetBool("isAlive", false);
                Targetable = false;
            }
        } get {
            return totalHealth;
        }
    }

    public bool Targetable {
        set {
            targetableObject = value;

            if (disableSimulation) {
                rb.simulated = false;
            }
            physicsCollider.enabled = value;
        } get {
            return targetableObject;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(float damage, Vector2 knockback) {
        Health -= damage;

        // Apply force to monster being hit
        rb.AddForce(knockback);
        Debug.Log("Force: " + knockback);
    }

    public void OnHit(float damage) {
        Health -= damage;
    }

    public void DestroyDead() {
        Debug.Log("Destroyed Dead Object");
        Destroy(gameObject);
    }
}
