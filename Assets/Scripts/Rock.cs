using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float initialSpeed = 2.0f;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log("Player detected, reducing speed and destroying rock.");
            player.ReduceSpeed(initialSpeed);
            Destroy(gameObject); // Destroy the rock after reducing the player's speed
        }
        else
        {
            Debug.Log("No PlayerController component found on the collided object.");
        }
    }
}
