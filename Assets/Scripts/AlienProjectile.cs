using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienProjectile : MonoBehaviour {
    public Vector3 thrust;
    public float speed;
    // Start is called before the first frame update
    void Start() {
        // thrust.y = -300.0f;
        GetComponent<Rigidbody>().drag = 0;
        // GetComponent<Rigidbody>().AddForce(thrust);
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update() {
        gameObject.transform.position += Vector3.down * speed * Time.deltaTime;

        // Destroy projectiles when they are off-screen
        if (gameObject.transform.position.y < -5) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;

        if (collider.CompareTag("Player")) {
            // Get the alien invader object and eliminate it
            PlayerShip playerShip = collider.gameObject.GetComponent<PlayerShip>();
            playerShip.Die();
            // destory the projectile
            Destroy(gameObject);
        } else if (collider.CompareTag("BarrierBlock")) {
            BarrierBlock block = collider.gameObject.GetComponent<BarrierBlock>();
            block.Die();
            // destory the projectile
            Destroy(gameObject);
        } else if (collider.CompareTag("Floor")) {
            // destory the projectile
            Destroy(gameObject);
        } else {
            Debug.Log("Collided with " + collider.tag);
        }
    }
}
