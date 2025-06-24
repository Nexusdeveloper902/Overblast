using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    public float speed = 5;
    public int health = 100;
    public float damageToIncrease;

    public event EventHandler OnHealthChanged;

    private bool godMode;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.N))
        {
            godMode = true;
        }

        if (godMode)
        {
            health = 100;
        }
    }
    
    void Movement()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            direction += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            direction += Vector3.down;
        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;
        if (Input.GetKey(KeyCode.A))
            direction += Vector3.left;

        transform.position += speed * Time.deltaTime * direction.normalized;
    }
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
        if (health <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void SpeedIncrease(float amount)
    {
        speed += amount;
        StartCoroutine(SpeedIncreaseTime());
    }

    IEnumerator SpeedIncreaseTime()
    {
        yield return new WaitForSeconds(10f);
        speed = 5;
    }

    public void DamageIncrease(float amount)
    {
        damageToIncrease += amount;
        StartCoroutine(DamageIncreaseTime());
    }

    IEnumerator DamageIncreaseTime()
    {
        yield return new WaitForSeconds(10f);
        damageToIncrease = 0;
    }
}