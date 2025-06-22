using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 10f;
   

    void Start()
    {
        damage = damage + Player.Instance.damageToIncrease;
        StartCoroutine(TimerToDespawn());
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    IEnumerator TimerToDespawn()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}