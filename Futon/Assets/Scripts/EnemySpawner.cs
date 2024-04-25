using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyPrefabAltitude
    {
        public GameObject enemyPrefab;
        public float minAltitude;
        public float maxAltitude;
        
    }

    public List<EnemyPrefabAltitude> airborneEnemyPrefabsWithAltitudes = new List<EnemyPrefabAltitude>();
    public List<GameObject> groundEnemyPrefabs = new List<GameObject>();
    public float spawnInterval = 3f; // Time interval between enemy spawns
    public float spawnRange = 5f; // Range in which airborne enemies can spawn in front of the player
    public float spawnRadius = 20f;
    public float groundSpawnRange = 2f; // Range in which ground enemies can spawn in front of the player
    


    private float nextSpawnTime; // Time when the next enemy will spawn

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // Schedule first spawn immediately
    }

    void Update()
    {
        // Check if it's time to spawn a new enemy
        if (Time.time >= nextSpawnTime)
        {
            // Select a random enemy prefab from the list
            GameObject selectedEnemyPrefab;

            if (Random.value < 0.5f && groundEnemyPrefabs.Count > 0)
            {
                // Randomly select a ground enemy if available
                selectedEnemyPrefab = groundEnemyPrefabs[Random.Range(0, groundEnemyPrefabs.Count)];
            }
            else if (airborneEnemyPrefabsWithAltitudes.Count > 0)
            {
                // Select a random airborne enemy prefab from the list
                EnemyPrefabAltitude selectedAirborneEnemyPrefab = airborneEnemyPrefabsWithAltitudes[Random.Range(0, airborneEnemyPrefabsWithAltitudes.Count)];
                selectedEnemyPrefab = selectedAirborneEnemyPrefab.enemyPrefab;

                // Calculate random altitude within the specified range for the selected enemy
                float altitude = Random.Range(selectedAirborneEnemyPrefab.minAltitude, selectedAirborneEnemyPrefab.maxAltitude);
        
                // Calculate random spawn position within spawn range
                Vector3 spawnOffset = new Vector3(spawnRadius, altitude);
                Vector3 spawnPosition = transform.position + transform.TransformDirection(spawnOffset);

                // Instantiate selected airborne enemy prefab at the calculated position
                Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);

                // Schedule next spawn time
                nextSpawnTime = Time.time + spawnInterval;

                return; // Exit early to prevent spawning additional enemies
            }
            else
            {
                // No airborne enemies available to spawn
                return; // Exit early
            }

            // Calculate random spawn position within ground spawn range
            Vector3 groundSpawnOffset = new Vector3(Random.Range(-groundSpawnRange, groundSpawnRange), 0f, groundSpawnRange);
            Vector3 groundSpawnPosition = transform.position + transform.TransformDirection(groundSpawnOffset);

            // Instantiate selected ground enemy prefab at the calculated position
            Instantiate(selectedEnemyPrefab, groundSpawnPosition, Quaternion.identity);

            // Schedule next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}