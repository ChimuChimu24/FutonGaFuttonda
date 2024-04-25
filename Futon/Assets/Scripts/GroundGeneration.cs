using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGeneration : MonoBehaviour
{
    [SerializeField] GameObject Tile;
    private Transform playerTransform;
    public float spawnX=1.0f;
    public float spawnY=1.0f;
    private float tileLength = 1;
    public int amnTilesOnScreen = 12;

    void Start()
    {   //finds the player object
        playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

        //spawns tiles on start time
        for(int i =0; i < amnTilesOnScreen;i++)
        {  
            SpawnTile();
        }
        
    }

    void Update()
    {   //spawns tiles based on player position
        if(playerTransform.position.x > (spawnX - amnTilesOnScreen*tileLength))
        {
            SpawnTile();
        }
    }
    //Tile spawn function.
    void SpawnTile(int prefabIndex = -1)
    {
        GameObject go; 
        go = Instantiate(Tile) as GameObject;
        go.transform.SetParent(transform);
        //decides spawn position
        go.transform.position = new Vector3(spawnX, spawnY, 0f);
        spawnX = spawnX + tileLength;
    }




}
