using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip audioClipBreak;
    Level level;
    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.AddBlock();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        level.RemoveBlock();
        AudioSource.PlayClipAtPoint(audioClipBreak, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
