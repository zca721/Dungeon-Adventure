using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MonsterController : MonoBehaviour {
    [SerializeField]    // Allows for variable to be private and still able to view from Unity Inspector
    private float collisionDamage = 5;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private  float knockbackForce = 500f;
    [SerializeField]
    private  DetectionZone detectionZone;

    Rigidbody2D rb;

    DamageableCharacter damageableCharacter;

    Animator animator;

    SpriteRenderer spriteRenderer;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    } 

    public void FixedUpdate() {
        // Collider2D firstDetectableObject = detectionZone.detectableObjects[0];

        if (damageableCharacter.Targetable && detectionZone.detectableObjects.Count > 0) {
            // Calculate direction towards Barbarian
            Vector2 direction = (detectionZone.detectableObjects[0].transform.position - transform.position).normalized;

            // Move towards Barbarian
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);

            // Sets direction of monster based off of Flip X being positve or negative
            if (direction.x < 0) {
                spriteRenderer.flipX = true;
            } else if (direction.x > 0) {
                spriteRenderer.flipX = false;
            }

            // Makes monster start run animation
            animator.SetBool("isMoving", true);
        } else {
            // Makes monster stop run animation
            animator.SetBool("isMoving", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        IDamageable damageableObject = collision.collider.GetComponent<IDamageable>();
        
        if (collision.collider.tag == "Player") {
            Debug.Log("Enemy Collision");
            if (damageableObject != null) {
                Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

                Vector2 direction = (Vector2) (collision.collider.gameObject.transform.position - parentPosition).normalized;

                Vector2 knockback = direction * knockbackForce;

                damageableObject.OnHit(collisionDamage, knockback);
            }
        }
    }
}
