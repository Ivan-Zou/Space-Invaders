using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveUI : MonoBehaviour {
    AlienInvaders invadersObj;
    TMP_Text waveText;
    // Start is called before the first frame update
    void Start() {
        GameObject g = GameObject.Find("AlienInvaders");
        invadersObj = g.GetComponent<AlienInvaders>();
        waveText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {
        waveText.text = "WAVE " + invadersObj.wave.ToString();
    }
}
