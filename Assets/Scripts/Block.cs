using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip audioClipBreak;
    [SerializeField] GameObject blockBreakerVFX;
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
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        level.RemoveBlock();
        gameState.addToScore();
        TriggerBlockBreakerVFX();
        AudioSource.PlayClipAtPoint(audioClipBreak, Camera.main.transform.position);
        Destroy(gameObject);
    }

    private void TriggerBlockBreakerVFX()
    {
        GameObject sparkles = Instantiate(blockBreakerVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2.0f);
    }
}
