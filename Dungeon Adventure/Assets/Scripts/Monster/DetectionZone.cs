using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour {
    public List<Collider2D> detectableObjects = new List<Collider2D>();

    public Collider2D detectionCollider;

    public AudioSource monsterAudio;

    void Start() {
        monsterAudio = GetComponent<AudioSource>();
    }

    // Detects when player is in range of monster
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            detectableObjects.Add(collider);
            monsterAudio.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") {
            detectableObjects.Remove(collider);
        }
    }
}
