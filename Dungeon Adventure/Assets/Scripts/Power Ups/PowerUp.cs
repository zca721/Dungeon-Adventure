using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public PowerUpEffect powerUpEffect;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Debug.Log("Power Up Applied");
            Destroy(gameObject);
            powerUpEffect.Apply(collision.gameObject);
        }
    }
}
