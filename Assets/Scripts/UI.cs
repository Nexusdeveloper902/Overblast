using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text healthTextNum;
    [SerializeField] private Text scoreTextNum;
    [SerializeField] private Text waveTextNum;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject waveText;
    [SerializeField] private GameObject healthText;
    [SerializeField] private GameObject levelUpPanel;
    
    public float maxHealth = 100;
    public static UI Instance;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    void Start()
    {
        healthTextNum.text = player.health.ToString() + "/" + maxHealth.ToString();
        player.OnHealthChanged += HandleHealthChanged;
    }

    void OnDestroy()
    {
        player.OnHealthChanged -= HandleHealthChanged;
    }
    
    private void HandleHealthChanged(object sender, System.EventArgs e)
    {
        healthTextNum.text = player.health.ToString() + "/" + maxHealth.ToString();
    }

    public void SetHealthInUI(int health)
    {
        healthTextNum.text = health.ToString() +"/" + maxHealth.ToString();
    }

    public void SetScoreInUI(int score)
    {
        scoreTextNum.text = score.ToString();
    }

    public void SetWaveInUI(int wave)
    {
        waveTextNum.text = wave.ToString();
    }

    public void ShowLevelUpPanel()
    {
        Time.timeScale = 0f;
        waveTextNum.gameObject.SetActive(false);
        healthTextNum.gameObject.SetActive(false);
        scoreTextNum.gameObject.SetActive(false);
        waveText.SetActive(false);
        scoreText.SetActive(false);
        healthText.SetActive(false);
        levelUpPanel.SetActive(true);
        UpgradeSystemUI.Instance.InstantiateUpgrades();
    }

    public void HideLevelUpPanel()
    {
        Time.timeScale = 1f;
        waveTextNum.gameObject.SetActive(true);
        healthTextNum.gameObject.SetActive(true);
        scoreTextNum.gameObject.SetActive(true);
        waveText.SetActive(true);
        scoreText.SetActive(true);
        healthText.SetActive(true);
        levelUpPanel.SetActive(false);
    }
}
