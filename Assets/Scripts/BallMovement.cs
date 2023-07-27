using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private float ydir;
    private float xdir;
    
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
        rb.velocity = new Vector2(speed * 0.7f, speed * 0.7f);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.GameObject.tag == "Player")
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
        else if (hit.GameObject.tag == "Wall")
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
        
    }
}
