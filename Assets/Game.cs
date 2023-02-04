using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject DangerTile;
    public GameObject SafeTile;

    public int[,] mazeTiles = new int[5,5];
    Vector2Int size = new Vector2Int(5,5);

    int[,] RandomMazeGenerator(int r, int c, Vector2Int p0, Vector2Int pf)
    {
        int[,] maze = new int[c,r];
        bool[,] seen = new bool[c,r];
        Vector2Int[,] previous = new Vector2Int[c,r];

        for (int i = 0; i < c; i++) {
            for (int j = 0; j < r; j++) {
                maze[i,j] = 0;
                seen[i,j] = false;
                previous[i,j] = new Vector2Int(-1,-1);
            }
        }

        Stack S = new Stack();
        S.Insert(p0);

        while(S.NotEmpty()) {
            Vector2Int position = S.Pop();
            seen[position.x, position.y] = true;
            Debug.Log(position);

            if (position.x+1 < r && maze[position.x+1,position.y] == 1 
                                    && previous[position.x,position.y] != new Vector2Int(position.x, position.y+1)) {
                if (0<position.x && maze[position.x-1,position.y] == 1
                                    && previous[position.x,position.y] != new Vector2Int(position.x-1, position.y)){
                    if (position.y+1 < c && maze[position.x,position.y+1] == 1 
                                            && previous[position.x,position.y] != new Vector2Int(position.x, position.y+1)){
                        if(position.y > 0 && maze[position.x,position.y-1] == 1
                                            && previous[position.x,position.y] != new Vector2Int(position.x, position.y-1)){
                            maze[position.x,position.y] = 1;

                            // Talvez quebre
                            List<Vector2Int> to_stack = new List<Vector2Int>();

                            if(position.x+1 < r && seen[position.x+1,position.y] == false){
                                seen[position.x-1,position.y] = true;

                                // System.Array.Resize(ref to_stack, to_stack.Length + 1);
                                // to_stack[to_stack.GetUpperBound(0)] = new Vector2Int(position.x-1,position.y);
                                to_stack.Add(new Vector2Int(position.x-1,position.y));

                                previous[position.x-1,position.y] = new Vector2Int(position.x,position.y);
                            }

                            if(position.y < c && seen[position.x,position.y+1] == false){
                                seen[position.x,position.y+1] = true;

                                // System.Array.Resize(ref to_stack, to_stack.Length + 1);
                                // to_stack[to_stack.GetUpperBound(0)] = new Vector2Int(position.x,position.y+1);
                                to_stack.Add(new Vector2Int(position.x,position.y+1));

                                previous[position.x,position.y+1] = new Vector2Int(position.x,position.y);
                            }

                            if(position.y>0 && seen[position.x,position.y-1]==false){
                                seen[position.x,position.y-1] = true;

                                // System.Array.Resize(ref to_stack, to_stack.Length + 1);
                                // to_stack[to_stack.GetUpperBound(0)] = new Vector2Int(position.x,position.y-1);
                                to_stack.Add(new Vector2Int(position.x,position.y-1));

                                previous[position.x,position.y-1] = new Vector2Int(position.x,position.y);
                            }

                            bool pf_flag = false;
                            while (to_stack.Count - 1 > 0) {
                                Vector2Int neighbour = to_stack[to_stack.Count - 1];
                                to_stack.RemoveAt(to_stack.Count - 1);

                                if(neighbour == pf){
                                    pf_flag = true;
                                } else {
                                    S.Insert(neighbour);
                                }
                            }

                            if (pf_flag == true){
                                S.Insert(pf);
                            }
                        }
                    }
                }
            }
        }

        maze[p0.x, p0.y] = 2;
        maze[pf.x, pf.y] = 3;

        return maze;
    }


    /*void Draw()
    {
        float fix = 1.1f * 2;
        for(int y = 0; y < 5; y = y + 1)
        {
            for(int x = 0; x < 5; x = x + 1)
            {
                GameObject plot;

                switch(mazeLogic[y,x])
                {
                    case 1:
                        plot = SafeTile;
                        break;
                    default:
                        plot = DangerTile;
                        break;
                }

                Instantiate(plot, new Vector3((1.1f * x) - fix, (-1.1f * y) + fix, 1), Quaternion.identity);
            }
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(RandomMazeGenerator(5, 5, new Vector2Int(0,0), new Vector2Int(4,4)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
