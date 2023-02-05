using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LastScore : MonoBehaviour {
    TMP_Text score;

    void Start() {
        score = GetComponent<TMP_Text>();
        score.text = "LAST SCORE: " + 0;
    }

    public void Set(int value) {
        score.text = "LAST SCORE: " + value;
    }
}
