using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour {

    public GameObject barrierObj;
    public float xPad;
    public Vector3 startPos;
    public int numBarriers;
    private GameObject[] barriers;
    // Start is called before the first frame update
    void Start() {
        xPad = 5.55f;
        startPos = new Vector3(-10.0f, 1.0f, 0);
        numBarriers = 4;
        barriers = new GameObject[numBarriers];
        SpawnBarriers();
    }

    void Update() {
        GameObject g = GameObject.Find("AlienInvaders");
        AlienInvaders invadersObj = g.GetComponent<AlienInvaders>();
        // Reset the barriers when all alien invaders are eliminated
        if (invadersObj.CountInvaders() == 0) {
            for (int i = 0; i < numBarriers; i++) {
                // Destroy remaining barriers onscreen
                GameObject barrier = barriers[i];
                if (barrier != null) {
                    Destroy(barrier);
                }
                // Spawn new barriers
                Vector3 spawnPos = startPos + new Vector3(i * xPad, startPos.y, 0);
                barrier = Instantiate(barrierObj, spawnPos, Quaternion.identity);
                barriers[i] = barrier;
            }
        }
    }

    void SpawnBarriers() {
        for (int i = 0; i < numBarriers; i++) {
            Vector3 spawnPos = startPos + new Vector3(i * xPad, startPos.y, 0);
            GameObject barrier = Instantiate(barrierObj, spawnPos, Quaternion.identity);
            barriers[i] = barrier;
        }
    }
}
