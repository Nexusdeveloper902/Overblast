using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private int healthToIncrease = 10;
    void  OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.name == "Player" && Player.Instance.health != 100)
        {
            Player.Instance.health += healthToIncrease;
            if (Player.Instance.health >= 100)
            {
                Player.Instance.health = 100;
            }
            UI.Instance.SetHealthInUI(Player.Instance.health);
            Destroy(gameObject);
        }
    }
}
