using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
   

    void Start()
    {
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
}