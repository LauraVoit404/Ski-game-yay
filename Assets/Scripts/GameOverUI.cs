using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject UICanvas;

     public void NextRace()
    {
        SceneManager.LoadScene("SkiGame_Couse3_Session4_Optimization 2");
        Time.timeScale = 1;
    }
     
     public void Restrart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
        public void QuitGame()
    {
        Application.Quit();
    }
}
