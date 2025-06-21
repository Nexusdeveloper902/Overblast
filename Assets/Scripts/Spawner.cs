using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private int enemyAmount = 3;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            StartCoroutine(SpawnerTimer());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnerTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0f);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
