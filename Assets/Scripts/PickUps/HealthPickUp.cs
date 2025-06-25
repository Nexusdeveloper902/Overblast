using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private int healthToIncrease = 10;
    void  OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.name == "Player" && Player.Instance.health != Player.Instance.maxHealth)
        {
            Player.Instance.health += healthToIncrease;
            if (Player.Instance.health >= Player.Instance.maxHealth)
            {
                Player.Instance.health = Player.Instance.maxHealth;
            }
            UI.Instance.SetHealthInUI(Player.Instance.health);
            Destroy(gameObject);
        }
    }
}
