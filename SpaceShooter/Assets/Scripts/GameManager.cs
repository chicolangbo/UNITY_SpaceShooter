using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsGameOver { get; private set; }

    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            gameOverText.SetActive(false);
        }
        else
        {
            Debug.LogWarning("GameManager instance already exists, destroying this one.");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(IsGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 현재 열려 있는 씬 재로드
        }
    }

    public void AddScore(int newScore)
    {
        if (IsGameOver)
            return;
        score += newScore;
        scoreText.text = $"SCORE : {score}";
    }
    
    public void OnPlayerDie()
    {
        IsGameOver = true;
        gameOverText.SetActive(true);
    }
}
