using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MonsterController : MonoBehaviour
{
    Animator animator;

    bool isAlive = true;

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
            }
        } get {
            return totalHealth;
        }
    }

    public float totalHealth = 30;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(float damage) {
        Health -= damage;
    }

    public void DestroyDeadMonster() {
        Destroy(gameObject);
    }
}
