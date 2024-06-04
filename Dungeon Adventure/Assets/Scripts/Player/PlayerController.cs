// Zachary Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour { // MonoBehavior allows for Unity to see and use the scripts
    public float moveSpeed = 1f;

    public float collisionOffset = 0.5f;

    public bool canMove = true;

    public ContactFilter2D movementFilter;

    public BarbarianAttacks punchAttack;

    Vector2 movementInput;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    private void FixedUpdate() {
        // Used for when attacking, we do not want to be able to move
        if (canMove) {
            // If movement input is not zero, then player moves
            if (movementInput != Vector2.zero) {
                bool success = TryMove(movementInput);

                // If movement is not possible, see if I can move in X direction
                if (!success) {
                    success = TryMove(new Vector2(movementInput.x, 0));

                    // If movement in X position is not possible, see if I can move in Y direction
                    if (!success) {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }
            
                // If moving is true, show character walking
                animator.SetBool("isMoving", success);
            } else {
                // If moving is false, show character idling
                animator.SetBool("isMoving", false);
            }

            // Sets direction of character based off of Flip X being positve or negative
            if (movementInput.x < 0) {
                spriteRenderer.flipX = true;
            } else if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
            }
        }
    }

    private bool TryMove(Vector2 direction) {
        // Checks if movement is greater or less than zero and if so allow movement
        if (direction != Vector2.zero) {
            // Check for potential collision.
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions.
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with.
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished.
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset.

            // If movement is greater or less than zero (zero means standing still) then move
            if(count == 0) {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }

        } else {
            // When collision is happening it makes character go from walking to idling
            return false;
        }
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire() {
        print("Punch attack");
        animator.SetTrigger("punchAttack");
    }

    public void PunchAttack() {
        LockMovement();
        if (spriteRenderer.flipX == true) {
            punchAttack.LeftAttack();
        } else {
            punchAttack.RightAttack();
        }
    }

    public void EndPunchAttack() {
        UnlockMovement();
        punchAttack.StopAttack();
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }
}
