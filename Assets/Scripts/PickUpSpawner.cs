using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public static  PickUpSpawner Instance;
    
    [SerializeField] private GameObject healthPickUp;
    [SerializeField] private GameObject damagePickUp;
    [SerializeField] private GameObject speedPickUp;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnHealthPickUp(Vector3 spawnPos)
    {
        Instantiate(healthPickUp, spawnPos, Quaternion.identity);
    }

    public void SpawnDamagePickUp(Vector3 spawnPos)
    {
        Instantiate(damagePickUp, spawnPos, Quaternion.identity);
    }
    
    public void SpawnSpeedPickUp(Vector3 spawnPos)
    {
        Instantiate(speedPickUp, spawnPos, Quaternion.identity);
    }

    public void PickUpsBetweenWaves()
    {
            float wave = Spawner.Instance.wave;
            

            // Increase drop chance with wave, but cap it to 50%
            float totalDropChance = Mathf.Min(0.1f + wave * 0.02f, 0.5f); // Starts at 10%, grows by 2% per wave

            float rand = Random.value;

            if (rand < totalDropChance)
            {
                // Decide which pickup to drop
                float typeRand = Random.value;

                if (typeRand < 0.2f)
                {
                    PickUpSpawner.Instance.SpawnSpeedPickUp(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f)); // 20% of total drop chance
                }
                else if (typeRand < 0.6f)
                {
                    PickUpSpawner.Instance.SpawnHealthPickUp(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f)); // 40%
                }
                else
                {
                    PickUpSpawner.Instance.SpawnDamagePickUp(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f)); // 40%
                }
            }
            // else: no drop
    }
}
