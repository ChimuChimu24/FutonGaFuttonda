using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public LaunchBarController launchBarController;
    public GameObject futon;
    public ArrowController arrowController;
    public FutonScript futonScript;
    public GameObject powerBar;

    private bool directionSelected = false;
    private bool launchPowerSelected = false; 
    
    
    void Start()
    {
        //Deactivates the Powerbar on startup
        powerBar.SetActive(false);
    }

    void Update()
    {

         if (Input.GetKeyDown(KeyCode.Space))
        {
            //Stops the arrow and activates the powerbar
            if (!directionSelected)
            {
                arrowController.rotating = false;
                directionSelected = true;
                Debug.Log("Direction Selected");
                powerBar.SetActive(true);

                
            }
            //Stops the powerbar and adds force to the futon
            else if (directionSelected && !launchPowerSelected)
            {
                launchBarController.LaunchPowerInputDetected();
                launchPowerSelected = true;
                //Debug.Log("LaunchPowerSelected");
                futonScript.AddForceToFuton();
                powerBar.SetActive(false);
            }

            else if (directionSelected&&launchPowerSelected)
            {
                futonScript.Jump();
            }
            
        }
        
        
    }
}