using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using TMPro;



public class ShopSystem : MonoBehaviour
{
    [Header("Shop variables")]
    public FutonScript futonScript; 
    public FutonSpriteScript futonSpriteScript;

    public int LaunchPowerLvl = 1; 
    public int MagnetismLvl = 0; 
    public int JumpLvl = 0; 
    public int BouncinessLvl = 0; 
    public int MoneyLvl = 0; 
    public int HealthLvl = 0; 
    

    public float launchPowerPrice;
    public float MagnetismPrice;
    public float JumpPrice;
    public float BouncinessPrice;
    public float MoneyPrice;
    public float HealthPrice;

    public float MoneyMultiplier;

    public TextMeshProUGUI launchPriceText;
    public TextMeshProUGUI jumpPriceText;
    public TextMeshProUGUI moneyPriceText;
    public TextMeshProUGUI bouncinessPriceText;

    [Header("Points variables")]
    public float distance;
    public float altitute; 
    public GameObject futon;
    public GameObject startingPoint;
    public int points; 
    public TextMeshProUGUI pointText;
    public int money;
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI currencyText2;
    public TextMeshProUGUI currencyText3;
    

    public float FinalMoney;


    private bool addedPoints;


    void Start()
    {
        
        addedPoints = false;

        LoadPowerLevel();
        LoadUpgradeJump();
        LoadUpgradeBounciness();
        LoadUpgradeMoney();

    }


    void Update()
    {
        CalculateDistance();
        UpdateText();
        //updates the text to display current points (distance)
        pointText.text = points.ToString();

            
    }

    public void UpgradeLaunchPower()
    {
        if(money >=  launchPowerPrice && LaunchPowerLvl <= 4)
        {
        LaunchPowerLvl++;

        LoadPowerLevel();
        currencyText3.text = money.ToString();
        }
    }

    public void UpgradeJumpPower()
    {
        if (money >= JumpPrice && JumpLvl <=4)
        {
        JumpLvl++; 

        LoadUpgradeJump();
        currencyText3.text = money.ToString();
        }
    }

    public void UpgradeMoney()
    {
        if (money >= MoneyPrice && MoneyLvl <=4)
        {
        MoneyLvl++;

        LoadUpgradeMoney();
        currencyText3.text = money.ToString();
        }
        
    }

    public void UpgradeBounciness()
    {
        if (money >=BouncinessPrice && BouncinessLvl <=2) 
        {
        BouncinessLvl++;
        
        LoadUpgradeBounciness();
        currencyText3.text = money.ToString();
        }
    }

    public void LoadPowerLevel()
    {

        if (LaunchPowerLvl == 0f)
        {
            launchPowerPrice = 100f;
        }
                switch (LaunchPowerLvl)
        {
            case 1: 
                if (money >= 100)
                {
                    futonScript.launchMultiplier = 1.5f;
                    money -= 100;
                    launchPowerPrice = 1000;
                    launchPriceText.text = launchPowerPrice.ToString();
                }
                break; 
                
            case 2:
                if (money >= 1000)
                {
                    futonScript.launchMultiplier = 2f;
                    money -= 5000;
                    launchPowerPrice = 2000;
                    launchPriceText.text = launchPowerPrice.ToString();
                }
                break;

            case 3:
                if (money >= 3500)
                {
                    futonScript.launchMultiplier = 5f;
                    money -= 3500;
                    launchPowerPrice = 10000;
                    launchPriceText.text = launchPowerPrice.ToString();
                }
                break;

            case 4:
                if (money >= 10000)
                {
                    futonScript.launchMultiplier = 10f;
                    money -= 10000;
                    launchPowerPrice = 100000;
                    launchPriceText.text = launchPowerPrice.ToString();
                }
                break;

            case 5:
                if (money >= 100000)
                {
                    futonScript.launchMultiplier = 20f;
                    money -= 100000;
                    launchPowerPrice = 100000;
                    launchPriceText.text = launchPowerPrice.ToString();
                    Debug.Log ("TESTTEST");
                }
                break;

        }
    }

    public void UpgradeMagnetism()
    {

    }

    public void LoadUpgradeJump()
    {
        if (JumpLvl == 0f)
        {
            JumpPrice = 100f;
            futonScript.jumpMultiplier = 0;
        }
                switch (JumpLvl)
        {
            case 1: 
                if (money >= 100)
                {
                    futonScript.jumpMultiplier = 1;
                    money -= 100;
                    JumpPrice = 500;
                    jumpPriceText.text = JumpPrice.ToString();
                }
                break; 
                
            case 2:
                if (money >= 500)
                {
                    futonScript.jumpMultiplier = 2;
                    money -= 500;
                    JumpPrice = 2000;
                    jumpPriceText.text = JumpPrice.ToString();
                }
                break;

            case 3:
                if (money >= 2000)
                {
                    futonScript.jumpMultiplier = 3;
                    money -= 2000;
                    JumpPrice = 5000;
                    jumpPriceText.text = JumpPrice.ToString();
                }
                break;

            case 4:
                if (money >= 5000)
                {
                    futonScript.jumpMultiplier = 4;
                    money -= 5000;
                    JumpPrice = 10000;
                    jumpPriceText.text = JumpPrice.ToString();
                }
                break;

            case 5:
                if (money >= 10000)
                {
                    futonScript.jumpMultiplier = 5;
                    money -= 10000;
                    JumpPrice = 10000;
                    jumpPriceText.text = JumpPrice.ToString();
                    //Debug.Log ("TESTTEST");
                }
                break;
        }
    }

    public void LoadUpgradeBounciness()
    {
        if (BouncinessLvl == 0f)
        {
            BouncinessPrice = 100f;
        }
                switch (BouncinessLvl)
        {
            case 1: 
                if (money >= 100)
                {
                    futonSpriteScript.bouncinessValue = 0.2f;
                    money -= 100;
                    BouncinessPrice = 500;
                    bouncinessPriceText.text = BouncinessPrice.ToString();
                }
                break; 
                
            case 2:
                if (money >= 500)
                {
                    futonSpriteScript.bouncinessValue = 0.35f;
                    money -= 500;
                    BouncinessPrice = 2000;
                    bouncinessPriceText.text = BouncinessPrice.ToString();
                }
                break;

            case 3:
                if (money >= 2000)
                {
                    futonSpriteScript.bouncinessValue = 0.5f;
                    money -= 2000;
                    BouncinessPrice = 5000;
                    bouncinessPriceText.text = BouncinessPrice.ToString();
                }
                break;
    }
}

    public void LoadUpgradeMoney()
    {

        if (MoneyLvl == 0f)
        {
            MoneyPrice = 100f;
            MoneyMultiplier = 1f;
        }
            switch (MoneyLvl)
        {
            case 1: 
                if (money >= 100)
                {
                    MoneyMultiplier = 1.2f;
                    money -= 100;
                    MoneyPrice = 500;
                    moneyPriceText.text = MoneyPrice.ToString();
                }
                break; 
                
            case 2:
                if (money >= 500)
                {
                    MoneyMultiplier = 1.5f;
                    money -= 500;
                    MoneyPrice = 2000;
                    moneyPriceText.text = MoneyPrice.ToString();
                }
                break;

            case 3:
                if (money >= 2000)
                {
                    MoneyMultiplier = 2f;
                    money -= 2000;
                    MoneyPrice = 5000;
                    moneyPriceText.text = MoneyPrice.ToString();
                }
                break;

            case 4:
                if (money >= 5000)
                {
                    MoneyMultiplier = 3f;
                    money -= 5000;
                    MoneyPrice = 10000;
                    moneyPriceText.text = MoneyPrice.ToString();
                }
                break;

            case 5:
                if (money >= 10000)
                {
                    MoneyMultiplier = 5f;
                    money -= 10000;
                    MoneyPrice = 10000;
                    moneyPriceText.text = MoneyPrice.ToString();
                    Debug.Log ("TESTTEST");
                }
                break;
        }
    }


    public void UpgradeHealth()
    {

    }


    public void ResetSave()
    {
        points = 0;
        LaunchPowerLvl = 0;
        MagnetismLvl = 0;
        JumpLvl = 0;
        BouncinessLvl = 0;
        MoneyLvl = 0;
        HealthLvl = 0;
        money = 0;
    }

//THIS IS WHERE THE POINTS FUNCTIONS START STARTS---------------------//


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
            
            money = money + points;
            addedPoints = true; 
            currencyText.text = money.ToString();
            currencyText2.text = money.ToString();
            currencyText3.text = money.ToString();
        }
        
    }

    public void UpdateText()
    {
        CalculateMoney();
        
        launchPriceText.text = launchPowerPrice.ToString();
        jumpPriceText.text = JumpPrice.ToString();
        bouncinessPriceText.text = BouncinessPrice.ToString();
        moneyPriceText.text = MoneyPrice.ToString();
    }

    public void cheatButton ()
    {
        money = money + 100000;
        CalculateMoney();
        currencyText3.text = money.ToString();
    }

}
