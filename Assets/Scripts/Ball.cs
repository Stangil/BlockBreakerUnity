﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float launchBallX = 2f;
    [SerializeField] float launchBallY = 15f;
    [SerializeField] AudioClip bounceSound;
    [SerializeField] AudioSource bounceSource;

    Vector2 paddleToBallVector;
    bool hasStarted = false;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchBallX, launchBallY);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bounce")|| collision.gameObject.CompareTag("Breakable") && hasStarted)
        {
            bounceSource.PlayOneShot(bounceSound);
        }
        
    }
}
