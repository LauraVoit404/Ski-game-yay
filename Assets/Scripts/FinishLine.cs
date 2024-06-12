using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject optionScreen; // Assign the OptionScreen panel in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            optionScreen.SetActive(true); // Show the option screen
            // You might also want to pause the game
            Time.timeScale = 0f; // This pauses the game
        }
    }
}