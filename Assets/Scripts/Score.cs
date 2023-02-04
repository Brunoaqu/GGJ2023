using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text ScoreText;
    int score = 1;

    private IEnumerator ScoreUp(float time) {
        while (true) {
            ScoreText.text = score.ToString();
            score++;
            yield return new WaitForSeconds(time);
        }
    }

    void Start() {
        StartCoroutine(ScoreUp(1));
    }

    // Update is called once per frame
    void Update() {

    }
}
