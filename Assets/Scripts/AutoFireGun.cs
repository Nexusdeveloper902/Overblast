using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFireGun : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject bulletPrefab;
    private GameObject[] enemies;
    
    
    void Start()
    {
        StartCoroutine(Shot());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position;
    }

    IEnumerator Shot()
    {
        while (true)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject closest = null;
            float minDist = Mathf.Infinity;

            foreach (var enemy in enemies)
            {
                float dist = (enemy.transform.position - transform.position).sqrMagnitude;

                if (dist < minDist)
                {
                    minDist = dist;
                    closest = enemy;
                }
            }
            Debug.Log(closest);
            if (closest != null)
            {
                Vector3 dir = closest.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
                Quaternion rot = Quaternion.Euler(0f, 0f, angle);

                Instantiate(bulletPrefab, transform.position, rot);
            }

            yield return new WaitForSeconds(1f); // adjust for your fire rate
        }
    }

}
