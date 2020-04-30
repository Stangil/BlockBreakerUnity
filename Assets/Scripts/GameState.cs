using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameState : MonoBehaviour
{
    [Range(0.1f,5.0f)] [SerializeField] float gameSpeed = 1.0f;
    [SerializeField] int pointsPerBlockDestroyed = 1;
    [SerializeField] int currentScore = 0;//for display in game editor
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameState>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    
    void Update()
    {
        Time.timeScale = gameSpeed;
        
    }
    public void addToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
    public void DestroyOnGameOver()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
