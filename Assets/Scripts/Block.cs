using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip audioClipBreak;
    [SerializeField] GameObject blockBreakerVFX;
    [SerializeField] int maxHits = 1;

    Level level;
    GameState gameState;
    [SerializeField] int timesHit; //TODO For viewing in game editor only
    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameState = FindObjectOfType<GameState>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level.AddBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            if(timesHit >= maxHits)
            {
                DestroyBlock();
            }
        }
    }

    private void DestroyBlock()
    {
        level.RemoveBlock();
        gameState.addToScore();
        PlayDestroySound();
        Destroy(gameObject);
    }

    private void PlayDestroySound()
    {
        TriggerBlockBreakerVFX();
        AudioSource.PlayClipAtPoint(audioClipBreak, Camera.main.transform.position);
    }

    private void TriggerBlockBreakerVFX()
    {
        GameObject sparkles = Instantiate(blockBreakerVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2.0f);
    }
}
