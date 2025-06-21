using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackCooldown = 1.0f;

    private float lastAttackTime;
    private Player playerScript;

    private enum State { Idle, Chase, Attack }
    private State currentState;

    void Start()
    {
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
                playerScript.TakeDamage(1);
            }
        }
    }
}