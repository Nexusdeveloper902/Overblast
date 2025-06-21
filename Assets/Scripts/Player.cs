using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    public int health = 100;

    public event EventHandler OnHealthChanged;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
           OnHealthChanged?.Invoke(this, EventArgs.Empty);
        }
        Movement();
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
}