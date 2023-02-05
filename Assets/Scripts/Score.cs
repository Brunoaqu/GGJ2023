using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour {
    public int scoreValue = 0;
    TMP_Text score;

    void Start() {
        score = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {
    }
}
