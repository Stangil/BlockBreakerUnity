using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float launchBallX = 2f;
    [SerializeField] float launchBallY = 15f;
    [SerializeField] AudioClip bounceSound;
    AudioSource bounceSource;
    [SerializeField] float randomFactor = 0.25f;
    Rigidbody2D myRigidbody2D;

    Vector2 paddleToBallVector;
    bool hasStarted = false;
    void Start()
    {
        bounceSource = GetComponent<AudioSource>();
        paddleToBallVector = transform.position - paddle1.transform.position;
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseCLick();
        }
    }

    private void LaunchOnMouseCLick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(launchBallX, launchBallY);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        
        if (collision.gameObject.CompareTag("Bounce") || collision.gameObject.CompareTag("Breakable") && hasStarted)
        {
            bounceSource.PlayOneShot(bounceSound);
            myRigidbody2D.velocity += velocityTweak;
        }
        
    }
}
