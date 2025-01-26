using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour {

    public int score, hiscore;
    public int lives;
    // Start is called before the first frame update
    void Start() {
        score = 0;
        hiscore = PlayerPrefs.GetInt("Hi-Score", 0);;
        lives = 3;
    }

    // Update is called once per frame
    void Update() {
        if (hiscore < score) {
            hiscore = score;
        }

        // Game Over
        if (lives == 0) {
            // Store Score and High Score
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetInt("Hi-Score", hiscore);
            // Load Game Over Scene
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
