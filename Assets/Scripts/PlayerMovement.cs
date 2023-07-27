using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    private float ydir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        ydir = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, speed * ydir);
    }
}
