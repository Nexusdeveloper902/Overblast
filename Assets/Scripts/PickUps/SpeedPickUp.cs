using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour
{
    [SerializeField] private float speedToIncrease = 2f;
    void  OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.name == "Player")
        {
            Player.Instance.SpeedIncrease(speedToIncrease);
            Destroy(gameObject);
        }
    }
}
