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
    private List<GameObject> currentScenario;

    [SerializeField] private Chronometer chronometer;
    [SerializeField] private Score score;
    // [SerializeField] private LastScore lastscore;
    private int counter = 1;

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

                var tile = Instantiate(plot, new Vector3(((1.5f * x) - 1.5f *2)+xFix, ((-1.5f * y) + 1.5f *2)+yFix, 1), Quaternion.identity);
                currentScenario.Add(tile);
            }
        }
        currentRoot = Instantiate(Root, new Vector3(-4.15f, 2.6f, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            Debug.Log("PlayerHit");
            Destroy(GameObject.FindWithTag("Player"));

            game.Destroy();

            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("RootPrefab");
            foreach(GameObject obj in allObjects) {
                Destroy(obj);
            }

            if (counter % 5 == 0 && counter != 0) {
                Debug.Log(counter);
                Debug.Log(counter % 2);

                chronometer.SetValue(chronometer.originalValue - 2);
            }

            chronometer.Reset();

            game.Draw(game.RandomMazeGenerator(5, 5, new Vector2Int(0,0), new Vector2Int(4,4)));
            
            score.Add();
            counter++;
        }
    }
}
