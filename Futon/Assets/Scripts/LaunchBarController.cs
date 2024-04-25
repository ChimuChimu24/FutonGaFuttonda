using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchBarController : MonoBehaviour
{
    public Slider launchSlider;
    public float moveSpeed = 1f;
    public float minValue = 0f;
    public float maxValue = 1f;
    public bool canInput = true;
    private float targetValue;
    public float launchPower;


    // Start is called before the first frame update
    void Start()
    {
        launchSlider = GetComponent<Slider>();
        launchSlider.minValue = minValue;
        launchSlider.maxValue = maxValue;
        targetValue = maxValue; // Start moving towards the maximum value
    }

    // Update is called once per frame
    void Update()
    {
        if (canInput)
        {

            float distanceToMiddle = Mathf.Abs(launchSlider.value - 1);
            float multiplier = Mathf.Lerp(3f, 1.25f, distanceToMiddle * 2f);

            float step = moveSpeed* multiplier  * Time.deltaTime;
            launchSlider.value = Mathf.MoveTowards(launchSlider.value, targetValue, step);
            

            // Check if the slider has reached the target value
            if (launchSlider.value == minValue || launchSlider.value == maxValue)
            {
                moveSpeed = moveSpeed *-1f;
            }
        }
    }

    void UpdateLaunchPower()
    {

        float launchPower = launchSlider.value;

    }

    // Call this method when the player input (e.g., spacebar) is detected
    public void LaunchPowerInputDetected()
    {
    canInput = false; // Disable further input
    float distanceTo05 = Mathf.Abs(launchSlider.value - 1);
    launchPower = Mathf.Clamp01(1f - (distanceTo05 - 0.025f) / 0.45f);

    // Adds 1.25* bonus if launchPower is close to 1.0f
    if (launchPower >= 0.9f)
    {
        launchPower = 1.25f;
    }

    if (launchPower <=0.25f)
    {
        launchPower = 0.25f;
    }

    else
    {
        launchPower = Mathf.Clamp01(launchPower); // Ensure launchPower is between 0 and 1
    }
        Debug.Log("Current power is" +launchPower);
    }

}

