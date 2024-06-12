﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
     public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
     public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
     public void Restrart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
