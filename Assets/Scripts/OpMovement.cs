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

    private float predictedYPos = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballScript = GetComponent<BallMovement>();
    }

    void FixedUpdate()
    {

        if (predictedYPos - this.transform.position.y > 0.1f)
        {
            rb.velocity = new Vector2(0.0f, speed);
        }
        else if (predictedYPos - this.transform.position.y < -0.1f)
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

        float a = (this.transform.position.x - ballXPos) * (ballYSpeed / ballXSpeed);
        float b = ballYPos + a;

        if (b > 4.4f)
        {
            predictedYPos = 8.8f - b;
        }
        else if (b < -4.4f)
        {
            predictedYPos = -8.8f - b;
        }
        else if (b > 8.8f)
        {
            predictedYPos = -17.6f + b;
        }
        else if (b < -8.8f)
        {
            predictedYPos = 17.6f - b;
        }
        else 
        {
            predictedYPos = b;
        }

        Debug.Log(predictedYPos);
    }
}
