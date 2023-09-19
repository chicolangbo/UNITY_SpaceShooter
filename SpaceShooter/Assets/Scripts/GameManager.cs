using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsGameOver { get; private set; } = false;

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
            AddScore(score);
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
        scoreText.text = $"SCORE : {AddZeroToDigit2(score)}";
    }
    
    public void OnPlayerDie()
    {
        IsGameOver = true;
        gameOverText.SetActive(true);
    }

    public static string AddZeroToDigit2(int number)
    {
        StringBuilder addZero = new StringBuilder();
        if(number < 10)
        {
            addZero.Append("0");
            addZero.Append(number);
        }
        return addZero.ToString();
    }
}
