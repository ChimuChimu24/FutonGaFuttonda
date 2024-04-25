using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackgroundLayer1 : MonoBehaviour
{
    public Sprite[] backgroundSprites; // Array to hold your background sprites
    public float spawnZPosition = 0f; // Z position where the background sprites will spawn

    [SerializeField] private Vector2 parallaxEffectMultipler;
    [SerializeField] private bool ActivateParallax;
    private Transform cameraTransform;
    private float spriteWidth;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        spriteWidth = backgroundSprites[0].bounds.size.x; // Assuming all sprites have the same size
        Sprite sprite = GetComponent<SpriteRenderer>().sprite; 
        
        // Initial spawn of background
        SpawnBackground();
    }

    private void FixedUpdate()
    {
        // Check if camera has moved enough to trigger background scrolling
        if (cameraTransform.position.x > transform.position.x + spriteWidth)
        {
            // Move the background to the right
            transform.position += Vector3.right * spriteWidth;
            
            // Spawn a new background sprite
            SpawnBackground();
        }
    }

    private void SpawnBackground()
    {
        // Randomly select a new background sprite
        int randomIndex = Random.Range(0, backgroundSprites.Length);
        Sprite randomSprite = backgroundSprites[randomIndex];

        // Create a new GameObject with the sprite
        GameObject newBackground = new GameObject("Background");
        SpriteRenderer spriteRenderer = newBackground.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = randomSprite;

        // Set the position of the new background
        Vector3 spawnPosition = transform.position + Vector3.right * spriteWidth;
        spawnPosition.z = spawnZPosition;
        newBackground.transform.position = spawnPosition;
    }

}