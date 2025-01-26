using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {
    private GUIStyle buttonStyle, titleStyle;
    
    // Start is called before the first frame update
    void Start() {
        buttonStyle = new GUIStyle();
        buttonStyle.normal.textColor = Color.white;
        buttonStyle.fontSize = 75;
        buttonStyle.alignment = TextAnchor.MiddleCenter; 
        buttonStyle.padding = new RectOffset(20, 20, 20, 20);

        titleStyle = new GUIStyle();
        titleStyle.normal.textColor = Color.white;
        titleStyle.fontSize = 200;
        titleStyle.alignment = TextAnchor.MiddleCenter;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnGUI() {
        // title
        GUI.Label(new Rect(0, 75, Screen.width, 100), "Space Invaders", titleStyle);

        GUILayout.BeginArea(new Rect(10, Screen.height / 2 + 100, Screen.width - 10, 300));
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
