using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutonSpriteScript : MonoBehaviour
{

    public float bouncinessValue = 0.5f; // Adjust the bounciness value as needed
    private PhysicsMaterial2D physicsMaterial;
    // Start is called before the first frame update
    void Start()
    {
         // Create a new physics material
    physicsMaterial = new PhysicsMaterial2D();

    // Set the bounciness property of the physics material
    physicsMaterial.bounciness = bouncinessValue;

    // Assign the physics material to the CapsuleCollider2D component of the GameObject
    CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
    if (collider != null)
    {
        collider.sharedMaterial = physicsMaterial;
    }
    else
    {
        Debug.LogWarning("CapsuleCollider2D component not found!");
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
