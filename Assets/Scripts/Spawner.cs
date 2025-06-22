using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public int enemiesAlive = 0;
    public int wave = 1;
    public bool readyForNextWave = false;
    
    [SerializeField] private GameObject enemyPrefab;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    void Start()
    {
        SpawnEnemies(1);
    }
    

    IEnumerator SpawnerTimer()
    {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0f);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemiesAlive++;
    }
    
    public void SpawnEnemies(int enemyAmount)
    {
        for (var i = 0; i < enemyAmount; i++)
        {
            StartCoroutine(SpawnerTimer());
        }
        wave++;
        UI.Instance.SetWaveInUI(wave);
    }
}
