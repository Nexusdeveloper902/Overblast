using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    public Transform playerTransform;
    public float speed = 5;
    public int health = 100;
    public float damageToIncrease;
    private float previousDamage;
    private float previousSpeed;
    public float xp;
    public float level;
    private float[] xpTable = new float[]
    {
        0f,   // Level 0 (not used)
        10f,  // Level 1
        25f,  // Level 2
        45f,  // Level 3
        70f,  // Level 4
        100f  // Level 5 (add more if needed)
    };
    
    public int maxHealth = 100;

    public event EventHandler OnHealthChanged;

    private bool godMode;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        playerTransform = GetComponent<Transform>();
    }
    
    void Update()
    {
        Movement();
        if (Input.GetKey(KeyCode.N) && !godMode)
        {
            godMode = true;
        }
        else if (Input.GetKey(KeyCode.N))
        {
            godMode = false;
        }

        if (godMode)
        {
            health = maxHealth;
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
        previousSpeed = speed;
        speed += amount;
        StartCoroutine(SpeedIncreaseTime());
    }

    IEnumerator SpeedIncreaseTime()
    {
        yield return new WaitForSeconds(10f);
        speed = previousSpeed;
    }

    public void DamageIncrease(float amount)
    {
        previousDamage = damageToIncrease;
        damageToIncrease += amount;
        StartCoroutine(DamageIncreaseTime());
    }

    IEnumerator DamageIncreaseTime()
    {
        yield return new WaitForSeconds(10f);
        damageToIncrease = previousDamage;
    }

    public void AddXp(float amount)
    {
        xp += amount;

        // Check if XP passed the threshold for the next level
        if (level < xpTable.Length - 1 && xp >= xpTable[(int)level + 1])
        {
            level++;
            LevelUp();
        }
    }

    void LevelUp()
    {
        maxHealth += 5;
        UI.Instance.maxHealth += 5;
        speed += 2;
        UI.Instance.SetHealthInUI(health);
        UI.Instance.ShowLevelUpPanel();
    }
}