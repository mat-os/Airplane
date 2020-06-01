using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUIController : MonoBehaviour
{
    [SerializeField]private GameObject pauseUI;
    
    private bool gameIsPaused;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            SwithcPauseState();
    }

    public void SwithcPauseState()
    {
        switch (gameIsPaused)
        {
            case false:
                PauseGame();
                break;

            case true:
                UnpauseGame();
                break;
        }
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        
        gameIsPaused = true;
    }
    
    private void UnpauseGame()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);

        gameIsPaused = false;
    }
}
