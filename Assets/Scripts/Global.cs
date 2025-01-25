using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    public int score, hiscore;
    public int lives;
    // Start is called before the first frame update
    void Start() {
        score = 0;
        hiscore = score;
        lives = 3;
    }

    // Update is called once per frame
    void Update() {
        if (hiscore < score) {
            hiscore = score;
        }
    }
}
