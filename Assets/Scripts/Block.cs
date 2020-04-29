using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip audioClipBreak;
    Level level;
    GameState gameState;
    private void Start()
    {
        gameState = FindObjectOfType<GameState>();
        level = FindObjectOfType<Level>();
        level.AddBlock();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        level.RemoveBlock();
        gameState.addToScore();
        AudioSource.PlayClipAtPoint(audioClipBreak, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
