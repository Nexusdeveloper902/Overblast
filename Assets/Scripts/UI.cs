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
    
    public static UI Instance;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    void Start()
    {
        healthText.text = player.health.ToString() + "/100";
        player.OnHealthChanged += HandleHealthChanged;
    }

    void OnDestroy()
    {
        player.OnHealthChanged -= HandleHealthChanged;
    }
    
    private void HandleHealthChanged(object sender, System.EventArgs e)
    {
        healthText.text = player.health.ToString() + "/100";
    }

    public void SetHealthInUI(int health)
    {
        healthText.text = health.ToString() + "/100";
    }

    public void SetScoreInUI(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetWaveInUI(int wave)
    {
        waveText.text = wave.ToString();
    }
}
