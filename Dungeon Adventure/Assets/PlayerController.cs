// Zachary Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.5f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    private void FixedUpdate()
    {
        // If movement input is not zero, then player moves
        if (movementInput != Vector2.zero) {
            // Check for potential collision.
            int count = rb.Cast(
                movementInput, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions.
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with.
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished.
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset.

            if(count == 0) {
                    rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }

        // Sets direction of character based off of Flip X being positve or negative
        if (movementInput.x < 0) {
            spriteRenderer.flipX = true;
        } else if (movementInput.x > 0) {
            spriteRenderer.flipX = false;
        }
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}
