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

    [SerializeField] private Score score;
    [SerializeField] private LastScore lastScore;

    public string lastMove;

    void Awake() 
    {
        lastMove = "down";
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Rock" || collider.gameObject.tag == "Borda") {
            Application.LoadLevel(Application.loadedLevel);

            Debug.Log(score.scoreValue);
            lastScore.Set(score.scoreValue);
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("left")){
            
            transform.rotation = Quaternion.Euler(0,0,-90);

            rootPos = roots.transform.position;
            float newX = roots.transform.position.x -1.6f ;
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
                Application.LoadLevel(Application.loadedLevel);
            }

            lastMove = "left";

        }
        if (Input.GetKeyDown("right")){
            
            transform.rotation = Quaternion.Euler(0,0,90);

            rootPos = roots.transform.position;
            float newX = roots.transform.position.x + 1.6f;
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
                Application.LoadLevel(Application.loadedLevel);
            }
            
            lastMove = "right";
        
        }
        if (Input.GetKeyDown("down")){
            
            transform.rotation = Quaternion.Euler(0,0,0);

            rootPos = roots.transform.position;
            float newX = roots.transform.position.x;
            float newY = roots.transform.position.y - 1.6f;
            float newZ = roots.transform.position.z;

            roots.transform.position = new Vector3(newX, newY, newZ);

            if (lastMove == "down"){
                Instantiate(leftRoot,rootPos,transform.rotation);
            } else if(lastMove == "right"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,180,270));
            } else if(lastMove == "left"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,0,270));
            } else if(lastMove == "up"){
                Application.LoadLevel(Application.loadedLevel);
            }

            lastMove = "down";

        }
        if (Input.GetKeyDown("up")){

            transform.rotation = Quaternion.Euler(0,0,180);

            rootPos = roots.transform.position;
            float newX = roots.transform.position.x;
            float newY = roots.transform.position.y + 1.6f;
            float newZ = roots.transform.position.z;

            roots.transform.position = new Vector3(newX, newY, newZ);

            if (lastMove == "up"){
                Instantiate(leftRoot,rootPos,transform.rotation);
            } else if(lastMove == "right"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,0,90));
            } else if(lastMove == "left"){
                Instantiate(rootCurve,rootPos,Quaternion.Euler(0,180,90));
            } else if(lastMove == "down"){
                Application.LoadLevel(Application.loadedLevel);
            }

            lastMove = "up";
        }
    }
}
