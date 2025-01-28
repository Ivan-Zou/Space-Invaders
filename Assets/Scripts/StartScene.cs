using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {
    private GUIStyle buttonStyle, titleStyle, scoreTextStyle;
    private int score, hiscore;

    // Start is called before the first frame update
    void Start() {
        // Reset Score and Hi-Score
        // PlayerPrefs.SetInt("Score", 0);
        // PlayerPrefs.SetInt("Hi-Score", 0);

        // Retrieve the score and high score
        score = PlayerPrefs.GetInt("Score", 0);
        hiscore = PlayerPrefs.GetInt("Hi-Score", 0);

        // set text styles
        buttonStyle = new GUIStyle();
        buttonStyle.normal.textColor = Color.white;
        buttonStyle.fontSize = 50;
        buttonStyle.alignment = TextAnchor.MiddleCenter; 
        buttonStyle.padding = new RectOffset(10, 10, 10, 10);

        titleStyle = new GUIStyle();
        titleStyle.normal.textColor = Color.white;
        titleStyle.fontSize = 100;
        titleStyle.alignment = TextAnchor.MiddleCenter;

        scoreTextStyle = new GUIStyle();
        scoreTextStyle.normal.textColor = Color.white;
        scoreTextStyle.fontSize = 50;
        scoreTextStyle.alignment = TextAnchor.MiddleCenter;
    }

    void OnGUI() {
        // Scores
        GUI.Label(new Rect(0, 50, Screen.width, 100), $"PREVIOUS SCORE: {score}  \t\t\t  HI-SCORE: {hiscore}", scoreTextStyle);
        // title
        GUI.Label(new Rect(0, 150, Screen.width, 100), "Space Invaders", titleStyle);

        GUILayout.BeginArea(new Rect(10, 275, Screen.width - 10, 300));
        // Load Gameplay scene
        if (GUILayout.Button("Play", buttonStyle)) {
            SceneManager.LoadScene("GameplayScene");
        }
        if (GUILayout.Button("Exit", buttonStyle)) {
            Application.Quit();
        }
        GUILayout.EndArea();
    }
}
