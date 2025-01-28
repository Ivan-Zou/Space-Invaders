using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {
    public int pointValue;
    public float speed, rotSpeed;
    // Start is called before the first frame update
    void Start() {
        int[] possiblePoints = new int[] {50, 100, 150, 200, 300};
        pointValue = possiblePoints[Random.Range(0, possiblePoints.Length)];
        speed = 5.0f;
        rotSpeed = 50.0f;
    }

    public AudioClip deathSound;
    public GameObject deathExplosion;
    public void Die() {
        // Play death sound
        AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);
        // Create explosion particles
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.identity);
        // Add points to score
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += pointValue;
        // Destroy object
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update() {
        // Move the UFO to the right
        Vector3 currentPos = gameObject.transform.position;
        currentPos.x += speed * Time.deltaTime;
        gameObject.transform.position = currentPos;
        // Rotate the UFO
        gameObject.transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        // Despawn the UFO when it goes out of the screen
        if (gameObject.transform.position.x > 22) {
            Destroy(gameObject);
        }
    }
}
