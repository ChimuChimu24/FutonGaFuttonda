using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxSpawner : MonoBehaviour
{
    public GameObject[] backgroundPrefabs; // Array to hold your background prefabs
    public float spawnZPosition = 0f; // Z position where the background objects will spawn
    private Transform cameraTransform;
    private float objectWidth;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        // Assuming all prefabs have the same width
        objectWidth = backgroundPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x;
        
        // Initial spawn of background
        SpawnBackground();
    }

    private void FixedUpdate()
    {
        // Check if camera has moved enough to trigger background scrolling
        if (cameraTransform.position.x > transform.position.x + objectWidth)
        {
            // Move the background to the right
            transform.position += Vector3.right * objectWidth;
            
            // Spawn a new background object
            SpawnBackground();
        }
    }

    private void SpawnBackground()
    {
        // Randomly select a new background prefab
        int randomIndex = Random.Range(0, backgroundPrefabs.Length);
        GameObject randomPrefab = backgroundPrefabs[randomIndex];

        // Instantiate the selected prefab
        GameObject newBackground = Instantiate(randomPrefab, transform.position, Quaternion.identity);
        
        // Set the Z position of the new background object
        newBackground.transform.position = new Vector3(newBackground.transform.position.x, newBackground.transform.position.y, spawnZPosition);
    }
}
