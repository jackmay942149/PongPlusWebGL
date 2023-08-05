using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpMovement : MonoBehaviour
{
    [SerializeField] private GameObject ballMovement;
    private BallMovement ballScript;
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    private float ballYSpeed;
    private float ballXSpeed;
    private float ballXPos;
    private float ballYPos;

    private float predictedYPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballScript = GetComponent<BallMovement>();
    }

    void FixedUpdate()
    {

        if (predictedYPos - this.transform.position.y > 0)
        {
            rb.velocity = new Vector2(0.0f, speed);
        }
        else if (predictedYPos - this.transform.position.y < 0)
        {
            rb.velocity = new Vector2(0.0f, -speed);
        }
        else
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }

    public void PredictPosition()
    {
        ballXPos = ballMovement.transform.position.x;
        ballYPos = ballMovement.transform.position.y;

        ballScript = ballMovement.GetComponent<BallMovement>();
        ballXSpeed = ballScript.XSpeed;
        ballYSpeed = ballScript.YSpeed;

        float angle = Mathf.Tan(ballYSpeed/ballXSpeed);
        float ballSpeed = Mathf.Sqrt(Mathf.Pow(ballXSpeed, 2) + Mathf.Pow(ballYSpeed, 2));
        predictedYPos = ballSpeed * Mathf.Sin(angle);


        Debug.Log(predictedYPos);
    }
}
