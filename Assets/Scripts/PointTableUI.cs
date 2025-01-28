using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTableUI : MonoBehaviour {
    private GUIStyle tableTextStyle, ufoTextStyle, largeInvaderTextStyle, medInvaderTextStyle, smallInvaderTextStyle;

    // Start is called before the first frame update
    void Start() {

        // set text styles
        tableTextStyle = new GUIStyle();
        tableTextStyle.normal.textColor = Color.yellow;
        tableTextStyle.fontSize = 50;
        tableTextStyle.alignment = TextAnchor.MiddleCenter;

        ufoTextStyle = new GUIStyle();
        ufoTextStyle.normal.textColor = Color.gray;
        ufoTextStyle.fontSize = 50;
        ufoTextStyle.alignment = TextAnchor.MiddleCenter;

        largeInvaderTextStyle = new GUIStyle();
        largeInvaderTextStyle.normal.textColor = Color.magenta;
        largeInvaderTextStyle.fontSize = 50;
        largeInvaderTextStyle.alignment = TextAnchor.MiddleCenter;

        medInvaderTextStyle = new GUIStyle();
        medInvaderTextStyle.normal.textColor = Color.cyan;
        medInvaderTextStyle.fontSize = 50;
        medInvaderTextStyle.alignment = TextAnchor.MiddleCenter;

        smallInvaderTextStyle = new GUIStyle();
        smallInvaderTextStyle.normal.textColor = Color.green;
        smallInvaderTextStyle.fontSize = 50;
        smallInvaderTextStyle.alignment = TextAnchor.MiddleCenter;
    }

    void OnGUI() {
        // Point Table Text
        GUI.Label(new Rect(20, 450, Screen.width, 100), "POINT TABLE", tableTextStyle);
        // UFO
        GUI.Label(new Rect(50, 550, Screen.width, 100), "  =   ?   MYSTERY", ufoTextStyle);
        // Small Invader
        GUI.Label(new Rect(25, 650, Screen.width, 100), "  =   30   POINTS", smallInvaderTextStyle);
        // Medium Invader
        GUI.Label(new Rect(25, 750, Screen.width, 100), "  =   20   POINTS", medInvaderTextStyle);
        // Large Invader
        GUI.Label(new Rect(25, 850, Screen.width, 100), "  =   10   POINTS", largeInvaderTextStyle);
        
    }
}
