using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float speed;
    public GameObject roots;
    public float rootsY = 0;
    public Vector3 rootPos;

    public GameObject downRoot;
    public GameObject rightRoot;
    public GameObject leftRoot;

    public GameObject rootCurve;

    public bool gameOver; 

    public string lastMove;

    void Awake() 
    {
        lastMove = "down";
    }

    // Update is called once per frame
    void Update () {
        


        if (Input.GetKeyDown("left")){
            
            transform.rotation = Quaternion.Euler(0,0,-90);

            rootPos = roots.transform.position;
            float newX = roots.transform.position.x -2 ;
            float newY = roots.transform.position.y;
            float newZ = roots.transform.position.z;

            roots.transform.position = new Vector3(newX, newY, newZ);

            if (lastMove == "left"){
                Instantiate(leftRoot,rootPos,transform.rotation);
            } else if(lastMove == "down"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,180,0));
            } else if(lastMove == "up"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,180,-90));
            } else if(lastMove == "right"){
                gameOver = true;
                Debug.Log(gameOver);
            }

            lastMove = "left";

        }
        if (Input.GetKeyDown("right")){
            
            transform.rotation = Quaternion.Euler(0,0,90);

            rootPos = roots.transform.position;
            float newX = roots.transform.position.x + 2;
            float newY = roots.transform.position.y;
            float newZ = roots.transform.position.z;

            roots.transform.position = new Vector3(newX, newY, newZ);

            if (lastMove == "right"){
                Instantiate(leftRoot,rootPos,transform.rotation);
            } else if(lastMove == "down"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,0,0));
            } else if(lastMove == "up"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,0,-90));
            } else if(lastMove == "left"){
                gameOver = true;
                Debug.Log(gameOver);
            }
            
            lastMove = "right";
        
        }
        if (Input.GetKeyDown("down")){
            
            transform.rotation = Quaternion.Euler(0,0,0);

            rootPos = roots.transform.position;
            float newX = roots.transform.position.x;
            float newY = roots.transform.position.y - 2;
            float newZ = roots.transform.position.z;

            roots.transform.position = new Vector3(newX, newY, newZ);

            if (lastMove == "down"){
                Instantiate(leftRoot,rootPos,transform.rotation);
            } else if(lastMove == "right"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,180,270));
            } else if(lastMove == "left"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,0,270));
            }

            lastMove = "down";

        }
        if (Input.GetKeyDown("up")){

            transform.rotation = Quaternion.Euler(0,0,180);

            rootPos = roots.transform.position;
            float newX = roots.transform.position.x;
            float newY = roots.transform.position.y + 2;
            float newZ = roots.transform.position.z;

            roots.transform.position = new Vector3(newX, newY, newZ);

            if (lastMove == "up"){
                Instantiate(leftRoot,rootPos,transform.rotation);
            } else if(lastMove == "right"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,0,90));
            } else if(lastMove == "left"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,180,90));
            }

            lastMove = "up";
        }
    }
}
