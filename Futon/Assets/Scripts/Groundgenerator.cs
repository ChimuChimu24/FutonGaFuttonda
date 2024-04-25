using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    public GameObject groundTilePrefab; // prefab for the ground tile
    public GameObject futon; // reference to the futon GameObject
    public float tileWidth = 1.28f; // width of the ground tile
    public int numTilesAhead = 5; // number of tiles to generate ahead of the futon

    private float lastTileXPos; // x position of the last generated tile

    void Start()
    {
        // Generate initial ground tiles
        for (int i = 0; i < numTilesAhead; i++)
        {
            GenerateTile();
        }
    }

    void Update()
    {
        // Check if we need to generate more ground tiles
        if (futon.transform.position.x > lastTileXPos - numTilesAhead * tileWidth)
        {
            GenerateTile();
        }

        // Move the ground to follow the futon
        transform.position = new Vector3(futon.transform.position.x, transform.position.y, transform.position.z);
    }

    void GenerateTile()
    {
        // Instantiate a new ground tile
        GameObject newTile = Instantiate(groundTilePrefab, transform);
        
        // Position the new tile to the right of the last generated tile
        newTile.transform.position = new Vector3(lastTileXPos + tileWidth, transform.position.y, transform.position.z);

        // Update the x position of the last generated tile
        lastTileXPos = newTile.transform.position.x;
    }
}