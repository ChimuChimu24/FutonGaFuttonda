using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffect : MonoBehaviour
{
    public float forceMagnitude = 10f; // Magnitude of the force to apply
    public Vector2 forceDirection = Vector2.left; // Direction of the force
    public ParticleSystem collisionParticles;

    public AudioClip attackSound; // Reference to the attack sound audio clip

    private bool isColliding = false;
    private AudioSource audioSource;

    public Vector3 moveDirection = Vector3.forward; // Default direction (forward)
    public float moveSpeed = 5f; // Default speed

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update ()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Apply force to the player
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                playerRigidbody.AddForce(forceDirection * forceMagnitude);
            }
            // Play Particles
            isColliding = true;
                if (isColliding == true)
                {
                    collisionParticles.Play();
                    Debug.Log("Playing particles now");
                }


            if (attackSound != null)
            {
            // Play the attack sound
            audioSource.PlayOneShot(attackSound);
            }

            Debug.Log("Player collision detected");


        }
    }

    
}
