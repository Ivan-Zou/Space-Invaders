using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
    private GUIStyle gameOverTextStyle, scoreTextStyle;
    private int score, hiscore;

    public float timeout, timer;
    // Start is called before the first frame update
    void Start() {
        timeout = 5.0f;
        timer = timeout;

        // Retrieve the score and high score
        score = PlayerPrefs.GetInt("Score", 0);
        hiscore = PlayerPrefs.GetInt("Hi-Score", 0);
        // set the style for the text
        gameOverTextStyle = new GUIStyle();
        gameOverTextStyle.normal.textColor = Color.red;
        gameOverTextStyle.fontSize = 200;
        gameOverTextStyle.alignment = TextAnchor.MiddleCenter;

        scoreTextStyle = new GUIStyle();
        scoreTextStyle.normal.textColor = Color.white;
        scoreTextStyle.fontSize = 100;
        scoreTextStyle.alignment = TextAnchor.MiddleCenter;
    }

    // Update is called once per frame
    void Update() {
        // show the Game Over scene for a certain timeout, then go to Start Scene
        timer -= Time.deltaTime;
        if (timer <= 0) {
            SceneManager.LoadScene("StartScene");
        }
    }

    void OnGUI() {
        // Game Over Text
        GUI.Label(new Rect(0, 200, Screen.width, 100), "GAME OVER!", gameOverTextStyle);
        // Score Text
        GUI.Label(new Rect(0, 450, Screen.width, 100), $"SCORE: {score}", scoreTextStyle);
        GUI.Label(new Rect(0, 600, Screen.width, 100), $"HI-SCORE: {hiscore}", scoreTextStyle);
    }
}
