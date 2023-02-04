using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour {
    public int scoreValue = 0;
    TMP_Text score;

    void Start() {
        score = GetComponent<TMP_Text>();
        Debug.Log(score.text);
    }

    // Update is called once per frame
    void Update() {
        scoreValue++;
        score.text = "SCORE: " + scoreValue;
    }
}
