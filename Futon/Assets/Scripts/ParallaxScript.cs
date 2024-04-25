using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float _startingPosX; // Starting position of the sprites on X-axis
    private float _startingPosY; // Starting position of the sprites on Y-axis
    private float _lengthOfSpriteX; // Length of the sprites on X-axis
    private float _lengthOfSpriteY; // Length of the sprites on Y-axis
    public float amountOfParallaxX; // Amount of parallax scroll for X-axis
    public float amountOfParallaxY; // Amount of parallax scroll for Y-axis
    public Camera mainCamera; // Reference to the camera

    // Start is called before the first frame update
    void Start()
    {
        // Getting the starting positions of the sprites
        _startingPosX = transform.position.x;
        _startingPosY = transform.position.y;
        
        // Getting the length of the sprites
        _lengthOfSpriteX = GetComponent<SpriteRenderer>().bounds.size.x;
        _lengthOfSpriteY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // LateUpdate is called once per frame, after Update
    void LateUpdate()
    {
        // Getting the position of the camera
        Vector3 cameraPosition = mainCamera.transform.position;

        // Calculating the temporary positions for both X and Y axes
        float tempX = cameraPosition.x * (1 - amountOfParallaxX);
        float tempY = cameraPosition.y * (1 - amountOfParallaxY);

        // Calculating the distance to move for both X and Y axes
        float distanceX = cameraPosition.x * amountOfParallaxX;
        float distanceY = cameraPosition.y * amountOfParallaxY;

        // Creating a new position vector with the calculated values
        Vector3 newPosition = new Vector3(_startingPosX + distanceX, _startingPosY + distanceY, transform.position.z);

        // Setting the new position
        transform.position = newPosition;

        // Checking if the sprites have moved out of view on the X-axis
        if (tempX > _startingPosX + (_lengthOfSpriteX / 2))
        {
            _startingPosX += _lengthOfSpriteX;
        }
        else if (tempX < _startingPosX - (_lengthOfSpriteX / 2))
        {
            _startingPosX -= _lengthOfSpriteX;
        }


    }
}