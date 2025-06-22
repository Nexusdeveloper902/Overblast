using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickUp : MonoBehaviour
{
    [SerializeField] private float damageToIncrease = 5f;
    void  OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.name == "Player")
        {
            Player.Instance.DamageIncrease(damageToIncrease);
            Destroy(gameObject);
        }
    }
}
