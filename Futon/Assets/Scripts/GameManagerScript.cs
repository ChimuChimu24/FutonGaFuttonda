using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public FutonScript futonScript;
    public GameObject gameOverUI;
    public ShopSystem shopSystem;
    public bool isGameOver;
    public GameObject shopUI; 
    public bool gameOverActive;
    public SaveData saveData;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
        LoadPlayer();
        shopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (futonScript.isGameOver&gameOverActive == false)
        {
            Debug.Log("Gameover");
            GameOver();
            gameOverActive = true; 
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        shopSystem.CalculateMoney();
        shopUI.SetActive(false);
        shopSystem.UpdateText();
    }

    public void SavePlayer ()
    {
        SaveSystem.SavePlayer(shopSystem);

        Debug.Log("Saved game");
    }


    public void LoadPlayer()
    {
        SaveData data = SaveSystem.LoadPlayer();

        shopSystem.money = data.Money;
        shopSystem.LaunchPowerLvl = data.LaunchPowerLvl;
        shopSystem.MagnetismLvl = data.MagnetismLvl;
        shopSystem.JumpLvl = data.JumpLvl;
        shopSystem.BouncinessLvl = data.BouncinessLvl;
        shopSystem.MoneyLvl = data.MoneyLvl;
        shopSystem.HealthLvl = data.HealthLvl;

        //shopSystem.launchPowerPrice = data.LaunchPowerPrice;

        Debug.Log("Loaded game");
    }



    public void OpenShop()
    {
       shopUI.SetActive(true); 
       gameOverUI.SetActive(false);
       
    }

        public void QuitGame()
    {
        // Quit the application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    
}
