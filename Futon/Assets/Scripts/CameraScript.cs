using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
  public Transform player;
  public Vector3 offset;

  public Rigidbody2D playerRigidbody;
    public float maxSpeed = 10f; // Maximum player speed
    public float maxZoomOut = 2f; // Maximum zoom-out factor
    public float minZoomOut = 1f; // Minimum zoom-out factor

  private Camera mainCamera;
  private float initialSize;
  
  void Start()
    {
        mainCamera = GetComponent<Camera>();
        initialSize = mainCamera.orthographicSize;
    }

  void Update () 
  {
    //follows player
      transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

        // Calculate normalized player speed (0 to 1)
        float normalizedSpeed = playerRigidbody.velocity.magnitude / maxSpeed;

        // Calculate the target zoom-out factor based on player speed
        float targetZoomOut = Mathf.Lerp(minZoomOut, maxZoomOut, normalizedSpeed);

        // Smoothly interpolate between current zoom and target zoom
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, initialSize * targetZoomOut, Time.deltaTime);
  }
      
}

