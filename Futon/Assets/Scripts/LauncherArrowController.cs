using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherArrowController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float minRotation = -45f;
    public float maxRotation = 45f;
    private float currentRotation = 0f;
    public float force = 10f;
    private bool isRotating = true;
    public GameObject launcherArrow;
    public GameObject futon;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite sprite = spriteRenderer.sprite;

        // Create a new sprite with the pivot point at the center
        sprite = Sprite.Create(sprite.texture, new Rect(0f, 0f, sprite.texture.width, sprite.texture.height),
                               new Vector2(0f, 0.5f), sprite.pixelsPerUnit);

        // Assign the new sprite to the sprite renderer
        spriteRenderer.sprite = sprite;
    }

    void Update()
    {
         if (isRotating)
        {
            // Calculate the target rotation based on the current rotation
            float targetRotation = Mathf.Round(currentRotation / 90f) * 90f - 90f;
            if (Mathf.Abs(currentRotation % 90) < 0.1f)
            {
                targetRotation += 0.1f;
            }

            GetCurrentRotation();

            // Rotate the arrow towards the target rotation
            currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);

            // Check if the arrow hits 12 o'clock or 3 o'clock, and change the direction of rotation accordingly
            if ((currentRotation <= -90f && targetRotation == -180f) || (currentRotation >= 90f && targetRotation == 0f))
            {
                rotationSpeed = -rotationSpeed;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D rb = futon.GetComponent<Rigidbody2D>();
            float launchAngle = launcherArrow.transform.rotation.eulerAngles.z;
            float launchAngleRad = launchAngle * Mathf.Deg2Rad;
            Vector2 launchDirection = new Vector2(Mathf.Cos(launchAngleRad), Mathf.Sin(launchAngleRad));
            rb.AddForce(launchDirection * force, ForceMode2D.Impulse);
            StopRotation();
        }
    }

    public void StopRotation()
    {
        // Stop the arrow from rotating
        isRotating = false;
    }

    public float GetCurrentRotation()
    {
        // Return the current rotation angle of the arrow
        return currentRotation;
    }
}
