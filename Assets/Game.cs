using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    int maze_size = 5;

    /*int RandomWalk(int[,] current_position, int[,] maze)
    {
        return Random.Range(0, 4);
    }*/

   private int[,] GenerateMatrix(int size)
    {
        return new int[size, size];
    }

    /*int[,] GenerateMaze (int size)
    {
        int[,] agent_location = [0, Random.range(0, size)];
        int[,] maze = new int[size, size];
    }*/
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GenerateMatrix(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
