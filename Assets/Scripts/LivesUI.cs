using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour {
    Global globalObj;
    TMP_Text livesText;
    // Start is called before the first frame update
    void Start() {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        livesText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {
        livesText.text = "LIVES: " + globalObj.lives.ToString();
    }
}
