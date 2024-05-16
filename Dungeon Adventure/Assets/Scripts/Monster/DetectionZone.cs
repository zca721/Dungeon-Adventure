using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectableObjects = new List<Collider2D>();
    public Collider2D detectionCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detects when player is in range of monster
    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            detectableObjects.Add(collider);
        }
        
    }

    public void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") {
            detectableObjects.Remove(collider);
        }
    }
}
