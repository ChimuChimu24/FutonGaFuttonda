using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsScript : MonoBehaviour
{

    public float distance;
    public float altitute; 
    public GameObject futon;
    public GameObject startingPoint;
    public int points; 
    public TextMeshProUGUI pointText;
    public int money;
    public TextMeshProUGUI currencyText;

    private bool addedPoints;

    void Start()
    {
        addedPoints = false;
    }

    void Update()
    {
        CalculateDistance();
        //updates the text to display current points (distance)
        pointText.text = points.ToString();
    
        currencyText.text = money.ToString();
    }
    //Calculates distance from starting position
    public void CalculateDistance()
    {
        distance = Mathf.Abs(futon.transform.position.x - startingPoint.transform.position.x);
        points = Mathf.RoundToInt(distance);
    }
    //Calculates altitude from starting position
    public void CalculateAltitude()
    {
        altitute = Mathf.Abs(futon.transform.position.y - startingPoint.transform.position.y);
    }

    public void CalculateMoney()
    {
        if(addedPoints == false)
        {
            money =  money + points;
            addedPoints = true; 
        }
        
    }

}
