using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;
    Ball ball;
    GameState gameState;
    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameState = FindObjectOfType<GameState>();
    }
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos() ,xMin, xMax);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (gameState.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
