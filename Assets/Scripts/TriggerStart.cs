using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStart : MonoBehaviour
{
    public PathCreator game; 

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            game.Draw(game.RandomMazeGenerator(5, 5, new Vector2Int(0,0), new Vector2Int(4,4)));
        }
    }
}
