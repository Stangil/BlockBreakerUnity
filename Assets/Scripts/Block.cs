using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip audioClipBreak;
    [SerializeField] GameObject blockBreakerVFX;
    [SerializeField] Sprite[] hitSprites; 
    Level level;
    GameState gameState;
    //[SerializeField] //TODO For viewing in game editor only
    int timesHit; 
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
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();        
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing  from array"+ gameObject.name);
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
