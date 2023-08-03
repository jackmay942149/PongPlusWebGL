using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpMovement : MonoBehaviour
{
    [SerializeField] private GameObject ballMovement;
    private BallMovement ballScript;
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    private float slowSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballScript = GetComponent<BallMovement>();
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(ballMovement.transform.position.y - this.transform.position.y) < 0.1f)
        {
            slowSpeed = ballMovement.GetComponent<BallMovement>().Yspeed;
        }
        else
        {
            slowSpeed = speed;
        }


        if (ballMovement.transform.position.y > this.transform.position.y) 
        {
            rb.velocity = new Vector2(0.0f, slowSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0.0f, -slowSpeed);
        }

    }
}
