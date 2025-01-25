using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HiScoreUI : MonoBehaviour {
    Global globalObj;
    TMP_Text hiscoreText;
    // Start is called before the first frame update
    void Start() {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        hiscoreText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {
        hiscoreText.text = "HI-SCORE: " + globalObj.hiscore.ToString();
    }
}
