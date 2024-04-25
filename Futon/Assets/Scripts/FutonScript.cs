using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutonScript : MonoBehaviour
{
    public float force; 
    public int torque;
    public Rigidbody2D rb;
    public ArrowController arrowController;
    public LaunchBarController LaunchBarController;
    public bool haveLaunched = false;

    public int jumpMultiplier;
    public float jumpPower = 10f;
    public int jumpAmount;

    public float stationaryTimeThreshold = 4f; //time threshold for game over
    public GameObject GameOverScreen;
    private float stationaryTimer =0f;
    private Vector3 previousPosition;
    public bool isGameOver = false;
    public ParticleSystem dust;

    public float launchMultiplier =1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousPosition = transform.position;

    }

    void Update()
    {
        
        StoppedMoving();


    }

    public void AddForceToFuton()
    { 
         //Gets launch direction from the Arrow rotation
        Vector3 launchDirection = Quaternion.Euler(0f, 0f, arrowController.arrowAngle) * Vector3.right;
        //changes the force based on the power bar
        force = force*LaunchBarController.launchPower;
        //Launches the object in obtained direction
        rb.AddForce(launchDirection * force * launchMultiplier);
        //Adds spin to the object     
        rb.AddTorque(torque);
        //Debug.Log("Shooting in following axis:" + arrowController.arrowAngle);

        haveLaunched=true;

        Debug.Log ("LaunchMultiplier is " + launchMultiplier);
    }

    public void StoppedMoving()
    {

        //Executes only after the game object has been launched
        if(haveLaunched==true)
        {

            float distance = Vector3.Distance(previousPosition, transform.position);

            if (distance > 0.00001)
            {
                stationaryTimer = 0f;
            }

            else
            {
                stationaryTimer +=Time.deltaTime;


                if(stationaryTimer >= stationaryTimeThreshold)
                {
                    isGameOver = true;
                    Debug.Log("GameOver!");
                }
            }
            previousPosition = transform.position;
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dust.Play();
            Debug.Log("Playing dust particle");
        }
    }

    public void Jump()
    {
        
        if (jumpAmount<jumpMultiplier)
        {
            jumpAmount++;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Debug.Log("I jumped");
        }
    }
}
