using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public bool rotating = true;
    public float arrowAngle;


    void Update()
    {
    if(rotating == true)
    {
        // Rotates arrow forward
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Check if rotation angle is between 90 and 95 degrees
        if (transform.eulerAngles.z >= 90 && transform.eulerAngles.z <= 100)
        {
            ChangeRotation();
        }
        
        // Check if rotation angle is between 0 and 5 degrees
        if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 5)
        {
            ChangeRotation();
        }
        }
    
        else 
        {
            //gathers angle of arrow when stopped (when not rotating). Used for telling the launch script where to launch.
        arrowAngle = transform.rotation.eulerAngles.z;
        }
        



    }
    //Function for changing rotation
    public void ChangeRotation()
    {
        rotationSpeed = rotationSpeed*-1;
    }
}
