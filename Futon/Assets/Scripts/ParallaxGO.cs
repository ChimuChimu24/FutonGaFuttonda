using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxGO : MonoBehaviour

{
    [SerializeField] private Vector2 parallaxEffectMultiplier = new Vector2(0.5f, 0.5f);
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void FixedUpdate()
    {
        // Calculate the delta movement of the camera
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        
        // Update the position of the GameObject to create the parallax effect
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0);

        // Update the last camera position for the next frame
        lastCameraPosition = cameraTransform.position;
    }
}