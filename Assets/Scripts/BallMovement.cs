using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private float yspeed;
    private float xspeed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitialMove();
    }

    void Update()
    {

    }
    
    private void InitialMove()
    {
        xspeed = speed * 0.7f;
        yspeed = speed * 0.7f;
        rb.velocity = new Vector2(xspeed, yspeed);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            xspeed *= -1.1f;
            yspeed *= 1.1f;
            rb.velocity = new Vector2(xspeed, yspeed);
        }
        else if (hit.gameObject.tag == "Wall")
        {
            yspeed *= -1.0f;
            rb.velocity = new Vector2(xspeed, yspeed);
            Debug.Log(rb.velocity.y);
        }
        
    }
}
