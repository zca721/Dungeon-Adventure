using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalPowerUp : MonoBehaviour
{
    public PowerUpEffect powerUpEffect;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Hitbox") {
            Debug.Log("Power Up Applied");
            Destroy(gameObject);
            powerUpEffect.Apply(collision.gameObject);
        }
    }
}
