using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float chaseRange = 50f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float moveSpeed = 2.3f;
    [SerializeField] private float attackCooldown = 1.0f;


    private int enemiesToSpawn;
    private float lastAttackTime;
    private Player playerScript;

    private enum State
    {
        Idle,
        Chase,
        Attack
    }

    private State currentState;

    [SerializeField] private float health = 30;
    [SerializeField] private int damageAmount = 20;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        playerScript = playerTransform.GetComponent<Player>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= attackRange)
            currentState = State.Attack;
        else if (distance <= chaseRange)
            currentState = State.Chase;
        else
            currentState = State.Idle;

        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Chase:
                Chase();
                break;
            case State.Attack:
                Attack();
                break;
        }
    }

    void Idle()
    {

    }

    void Chase()
    {
        Vector3 dir = (playerTransform.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            if (playerScript != null)
            {
                playerScript.TakeDamage(damageAmount);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        enemiesToSpawn = Spawner.Instance.wave;
        Debug.Log(enemiesToSpawn);
        health -= amount;
        if (health <= 0)
        {
            GameManager.Instance.AddScore(5);
            Spawner.Instance.enemiesAlive--;
            if (Spawner.Instance.enemiesAlive == 0)
            {
                Spawner.Instance.readyForNextWave = true;
                {
                    Spawner.Instance.readyForNextWave = false;
                    Spawner.Instance.WaitBeforeNextWaveFunc(enemiesToSpawn);
                }
            }

            Destroy(gameObject);
        }
    }
    
}