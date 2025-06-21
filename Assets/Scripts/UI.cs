using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text healthText;
    // Start is called before the first frame update
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
    void Update()
    {
        
    }
}
