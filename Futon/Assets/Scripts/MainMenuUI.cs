using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuUI : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Get the index of the current active scene
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene by incrementing the current index
        SceneManager.LoadScene(currentIndex + 1);
    }
}

