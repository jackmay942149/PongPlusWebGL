using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpMovement : MonoBehaviour
{
    [SerializeField] private GameObject ballMovement;
    private Rigidbody2D rb;

    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (ballMovement.transform.position.y > this.transform.position.y) 
        {
            rb.velocity = new Vector2(0.0f, speed);
        }
        else
        {
            rb.velocity = new Vector2(0.0f, -speed);
        }
    }
}
