using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    public GameObject DangerTile;
    public GameObject SafeTile;
    public GameObject Root;


    private List<GameObject> scenario = new List<GameObject> ();
    
    public int[,] mazeTiles = new int[5,5];
    Vector2Int size = new Vector2Int(5,5);

    public int[,] RandomMazeGenerator(int r, int c, Vector2Int p0, Vector2Int pf)
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

        while(S.NotEmpty() != false) {
            Vector2Int position = S.Pop();
            seen[position.x, position.y] = true;

            if (position.x + 1 < r && maze[position.x + 1,position.y] == 1 && previous[position.x,position.y] != new Vector2Int(position.x+1, position.y)) {
                continue;
            }
            if (position.x > 0 && maze[position.x-1,position.y] == 1 && previous[position.x,position.y] != new Vector2Int(position.x-1, position.y)){
                continue;
            }
            if (position.y + 1 < c && maze[position.x,position.y+1] == 1 && previous[position.x,position.y] != new Vector2Int(position.x, position.y+1)){
                continue;
            }
            if (position.y > 0 && maze[position.x,position.y-1] == 1 && previous[position.x,position.y] != new Vector2Int(position.x, position.y-1)){
                continue;
            }
                            
            maze[position.x,position.y] = 1;

            List<Vector2Int> to_stack = new List<Vector2Int>();

            if(position.x+1 < r && seen[position.x+1,position.y] == false){                
                seen[position.x+1,position.y] = true;

                to_stack.Add(new Vector2Int(position.x+1,position.y));

                previous[position.x+1,position.y] = new Vector2Int(position.x,position.y);
            }

            if (0 < position.x && seen[position.x-1,position.y] == false){
                seen[position.x-1,position.y] = true;

                to_stack.Add(new Vector2Int(position.x-1,position.y));

                previous[position.x-1,position.y] = new Vector2Int(position.x,position.y);
            }

            if(position.y + 1< c && seen[position.x,position.y + 1] == false){
                seen[position.x,position.y + 1] = true;

                to_stack.Add(new Vector2Int(position.x,position.y+1));

                previous[position.x,position.y+1] = new Vector2Int(position.x,position.y);
            }

            if(position.y > 0 && seen[position.x,position.y-1]==false){
                seen[position.x,position.y-1] = true;

                to_stack.Add(new Vector2Int(position.x,position.y-1));

                previous[position.x,position.y-1] = new Vector2Int(position.x,position.y);
            }

            bool pf_flag = false;

            while (to_stack.Count > 0) {
                int randomNumber = Random.Range(0, to_stack.Count);
                
                Vector2Int neighbour = to_stack[randomNumber];
                to_stack.RemoveAt(randomNumber);

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

        // End of generation;
        maze[p0.x, p0.y] = 2;
        maze[pf.x, pf.y] = 3;
        return maze;
    }

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

                GameObject _new = (GameObject) Instantiate(plot, new Vector3(((1.5f * x) - 1.5f *2)+xFix, ((-1.5f * y) + 1.5f *2)+yFix, 3), Quaternion.identity);
                scenario.Add(_new);
            }
        }
        scenario.Add(Instantiate(Root, new Vector3(-4.15f, 2.6f, 2), Quaternion.identity));
    }

    public void Destroy()
    {
        foreach(GameObject obj in scenario) {
            Destroy(obj);
        }
    }
}