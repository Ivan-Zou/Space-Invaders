using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public Vector3 forceVector;
    public float maxSpeed;

    // Start is called before the first frame update
    void Start() {
        forceVector.x = 20.0f;
        maxSpeed = 50.0f;
    }

    void FixedUpdate() {
        // Move ship left and right
        if (Input.GetAxisRaw("Horizontal") > 0) {
            if (GetComponent<Rigidbody>().velocity.x <= maxSpeed) {
                GetComponent<Rigidbody>().AddForce(forceVector);
            }
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            if (GetComponent<Rigidbody>().velocity.x >= -maxSpeed) {
                GetComponent<Rigidbody>().AddForce(-forceVector);
            }
        }

        // Keep ship within the bounds of the floor
        Vector3 currPos = gameObject.transform.position;
        if (currPos.x > 14.5f) {
            currPos.x = 14.5f;
        } else if (currPos.x < -14.5f) {
            currPos.x = -14.5f;
        }
        gameObject.transform.position = currPos;

    }

    public GameObject projectile;
    public AudioClip shootSound;
    // Update is called once per frame
    void Update() {
        // Fire the player projectile
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) {
            Debug.Log("Player Fires!");
            // Play shoot sound
            AudioSource.PlayClipAtPoint(shootSound, gameObject.transform.position);
            // Spawn Projectile
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.y = 1.5f;
            GameObject obj = Instantiate(projectile, spawnPos, Quaternion.identity) as GameObject;
            
        }
    }

    public AudioClip damagedSound;
    public void Die() {
        // Play damaged sound
        AudioSource.PlayClipAtPoint(damagedSound, gameObject.transform.position);
        // Decrease lives by 1;
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.lives--;
    }
}
