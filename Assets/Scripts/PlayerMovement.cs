using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float jump;
    public float speed;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            rb.AddForce(Vector2.up * jump);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other) 
    {
       if (other.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
