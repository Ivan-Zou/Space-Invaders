using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public Vector3 thrust;
    // Start is called before the first frame update
    void Start() {
        thrust.y = 1000.0f;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().AddForce(thrust);
    }

    // Update is called once per frame
    void Update() {
        // Destroy projectiles when they are off-screen
        if (gameObject.transform.position.y > 50) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;

        if (collider.CompareTag("LargeAlienInvader")) {
            // Get the alien invader object and eliminate it
            LargeAlienInvader alienInvader = collider.gameObject.GetComponent<LargeAlienInvader>();
            alienInvader.Die();
            // destory the projectile
            Destroy(gameObject);

        } else if (collider.CompareTag("MediumAlienInvader")) {
            // Get the alien invader object and eliminate it
            MediumAlienInvader alienInvader = collider.gameObject.GetComponent<MediumAlienInvader>();
            alienInvader.Die();
            // destory the projectile
            Destroy(gameObject);
        } else if (collider.CompareTag("SmallAlienInvader")) {
            // Get the alien invader object and eliminate it
            SmallAlienInvader alienInvader = collider.gameObject.GetComponent<SmallAlienInvader>();
            alienInvader.Die();
            // destory the projectile
            Destroy(gameObject);
        } else if (collider.CompareTag("UFO")) {
            // Get the UFO object and eliminate it
            UFO ufo = collider.gameObject.GetComponent<UFO>();
            ufo.Die();
            // destory the projectile
            Destroy(gameObject);
        } else if (collider.CompareTag("BarrierBlock")) {
            BarrierBlock block = collider.gameObject.GetComponent<BarrierBlock>();
            block.Die();
            // destory the projectile
            Destroy(gameObject);
        } else {
            Debug.Log("Collided with " + collider.tag);
        }
    }
}
