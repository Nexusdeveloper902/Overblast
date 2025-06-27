using System.Collections.Generic;
using UnityEngine;

public class OrbContainer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;    // Reference to the player
    [SerializeField] private GameObject orbPrefab;         // Your orb prefab
    [SerializeField] private int orbCount = 3;             // How many orbs
    [SerializeField] private float radius = 2f;            // Orbit radius
    [SerializeField] private float rotationSpeed = 45f;    // Degrees per second

    private List<Transform> spawnedOrbs = new List<Transform>();

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // Spawn orbs
        for (int i = 0; i < orbCount; i++)
        {
            GameObject orb = Instantiate(orbPrefab, transform);

            // Compute angle in degrees
            float angle = i * (360f / orbCount);

            // Convert angle to radians for positioning
            float rad = angle * Mathf.Deg2Rad;

            // Set local position on the circle
            Vector3 localPos = new Vector3(
                Mathf.Cos(rad) * radius,
                Mathf.Sin(rad) * radius,
                0f
            );

            orb.transform.localPosition = localPos;

            spawnedOrbs.Add(orb.transform);
        }
    }

    void Update()
    {
        // Rotate the whole container
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        // Keep container centered on the player
        if (playerTransform != null)
        {
            transform.position = playerTransform.position;
        }
    }
}