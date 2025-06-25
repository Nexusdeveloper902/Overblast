using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text waveText;
    
    public float maxHealth = 100;
    public static UI Instance;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    void Start()
    {
        healthText.text = player.health.ToString() + "/" + maxHealth.ToString();
        player.OnHealthChanged += HandleHealthChanged;
    }

    void OnDestroy()
    {
        player.OnHealthChanged -= HandleHealthChanged;
    }
    
    private void HandleHealthChanged(object sender, System.EventArgs e)
    {
        healthText.text = player.health.ToString() + "/" + maxHealth.ToString();
    }

    public void SetHealthInUI(int health)
    {
        healthText.text = health.ToString() +"/" + maxHealth.ToString();
    }

    public void SetScoreInUI(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetWaveInUI(int wave)
    {
        waveText.text = wave.ToString();
    }

    public void LevelUpPanel()
    {
        
    }
}
