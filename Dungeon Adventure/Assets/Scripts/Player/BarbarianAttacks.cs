// Zachary Anderson

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarbarianAttacks : MonoBehaviour {

    public float punchDamage = 10;
    public float knockbackForce = 500f;
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

    public void OnTriggerEnter2D(Collider2D collider) {

        IDamageable damageableObject = collider.GetComponent<IDamageable>();

        if (collider.tag == "Monster") {

            if (damageableObject != null) {
                // Barabarian deals damage to enemy
                MonsterController monster = collider.GetComponent<MonsterController>();

                // Calculate direction between Barbarian and Monster
                Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

                Vector2 direction = (Vector2) (collider.gameObject.transform.position - parentPosition).normalized;

                Vector2 knockback = direction * knockbackForce;

                if (monster != null) {
                    damageableObject.OnHit(punchDamage, knockback);
                    // monster.SendMessage("OnHit", punchDamage, knockback);
                }
            }
        }
    }
}
