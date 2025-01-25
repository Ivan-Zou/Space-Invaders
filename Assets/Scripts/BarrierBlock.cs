using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBlock : MonoBehaviour {
    public void Die() {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;
        // Destroy the barrier block when it collides with an alien invader
        if (collider.CompareTag("LargeAlienInvader") || collider.CompareTag("MediumAlienInvader") || collider.CompareTag("SmallAlienInvader")) {
            Destroy(gameObject);
        } 
    }
}
