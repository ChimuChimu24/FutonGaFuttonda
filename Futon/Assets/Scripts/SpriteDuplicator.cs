using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDuplicator : MonoBehaviour
{
    public GameObject spritePrefab; // Reference to the sprite prefab you want to duplicate
    public RectTransform canvasRectTransform; // Reference to the RectTransform of the UI canvas
    public float yOffset = 100f; // Adjust this value to change the spawn position vertically

    void Start()
    {
        // Calculate the dimensions of the canvas in world units
        Vector2 canvasSize = canvasRectTransform.sizeDelta;

        // Calculate the number of rows and columns needed to cover the canvas
        int rows = Mathf.CeilToInt(canvasSize.y / spritePrefab.GetComponent<RectTransform>().sizeDelta.y);
        int columns = Mathf.CeilToInt(canvasSize.x / spritePrefab.GetComponent<RectTransform>().sizeDelta.x);

        // Instantiate the sprites to cover the canvas
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Vector3 position = new Vector3(
                    column * spritePrefab.GetComponent<RectTransform>().sizeDelta.x,
                    (rows - row - 1) * spritePrefab.GetComponent<RectTransform>().sizeDelta.y + yOffset, // Add yOffset

                    0f
                );

                GameObject spriteInstance = Instantiate(spritePrefab, position, Quaternion.identity, transform);
                spriteInstance.transform.SetParent(transform, false); // Ensure correct parent-child relationship within the canvas
            }
        }
    }
}