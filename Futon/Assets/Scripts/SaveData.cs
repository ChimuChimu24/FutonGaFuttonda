using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public int points;
    public int LaunchPowerLvl ; 
    public int MagnetismLvl; 
    public int JumpLvl; 
    public int BouncinessLvl; 
    public int MoneyLvl; 
    public int HealthLvl; 
    public int Money;

    public float LaunchPowerPrice;

    public SaveData (ShopSystem shopSystem)
    {
        points = shopSystem.points;
        LaunchPowerLvl = shopSystem.LaunchPowerLvl;
        MagnetismLvl = shopSystem.MagnetismLvl;
        JumpLvl = shopSystem.JumpLvl;
        BouncinessLvl = shopSystem.BouncinessLvl;
        MoneyLvl = shopSystem.MoneyLvl;
        HealthLvl = shopSystem.HealthLvl;
        Money = shopSystem.money;

        //LaunchPowerPrice = shopSystem.launchPowerPrice;
    }

}
