using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Text highScoreText;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject healthText;
    
    public int score = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UI.Instance.SetScoreInUI(0);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        scoreText.SetActive(false);
        healthText.SetActive(false);
        
        highScoreText.text = "High score: " + score.ToString();
            
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);  
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int  scoreToAdd)
    {
        score += scoreToAdd;
        UI.Instance.SetScoreInUI(score);
    }
}