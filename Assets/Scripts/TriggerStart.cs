using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStart : MonoBehaviour
{
    public PathCreator game;
    public GameObject DangerTile;
    public GameObject SafeTile;
    public GameObject Root;

    private GameObject currentRoot;

    public void Draw(int[,] mazeLogic)
    {
        float xFix = -1.25f;
        float yFix = -0.4f;
        for(int y = 0; y < 5; y = y + 1)
        {
            for(int x = 0; x < 5; x = x + 1)
            {
                GameObject plot;

                switch(mazeLogic[y,x])
                {
                    case 0:
                        plot = DangerTile;
                        break;
                    default:
                        plot = SafeTile;
                        break;
                }

                Instantiate(plot, new Vector3(((1.5f * x) - 1.5f *2)+xFix, ((-1.5f * y) + 1.5f *2)+yFix, 1), Quaternion.identity);
            }
        }
        currentRoot = Instantiate(Root, new Vector3(-4.15f, 2.6f, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            Destroy(GameObject.FindWithTag("Player"));

            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("RootPrefab");
            foreach(GameObject obj in allObjects) {
                Destroy(obj);
            }

            Draw(game.RandomMazeGenerator(5, 5, new Vector2Int(0,0), new Vector2Int(4,4)));
        }
    }
}
