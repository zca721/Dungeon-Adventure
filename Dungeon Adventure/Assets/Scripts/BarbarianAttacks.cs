// Zachary Anderson

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarbarianAttacks : MonoBehaviour {

    public float punchDamage = 10;
    public Collider2D punchCollider;
    Vector2 attackOffset;
    
    // Start is called before the first frame update
    void Start() {
        attackOffset = transform.position;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void RightAttack() {
        print("Attack right");
        punchCollider.enabled = true;
        transform.localPosition = attackOffset;

    }

    public void LeftAttack() {
        print("Attack left");
        punchCollider.enabled = true;
        transform.localPosition = new Vector3(attackOffset.x * -1, attackOffset.y);

    }

    public void StopAttack() {
        punchCollider.enabled = false;

    }

    public void OnTriggerEnter2D(Collider2D enemy) {
        if (enemy.tag == "Enemy") {
            // Barabarian deals damage to enemy
        }
    }

    
}
