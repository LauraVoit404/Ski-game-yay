using UnityEngine;
using System.Collections;

public class SnowmanThrow : MonoBehaviour
{
    public float throwSpeed = 10f;
    private bool justThrown = false;
    private ObjectPool objectPool; // Reference to the ObjectPool component in the scene
    private Transform playerTransform; // Reference to the player's transform

    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>(); // Find the ObjectPool component in the scene
        if (objectPool == null)
        {
            Debug.LogError("ObjectPool component not found in the scene!");
        }

        // Find the player's transform
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }

    void Update()
    {
        if (!justThrown && playerTransform != null)
        {
            ThrowSnowball();
        }
    }

    void ThrowSnowball()
    {
        justThrown = true;
        
        // Get a snowball from the pool
        GameObject tempSnowBall = objectPool.GetPooledObject();
        if (tempSnowBall == null)
        {
            Debug.LogError("No snowball available in the pool!");
            justThrown = false;
            return;
        }

        // Calculate direction towards the player
        Vector3 targetDirection = (playerTransform.position - transform.position).normalized;

        // Set position, rotation, and activate snowball
        tempSnowBall.transform.position = transform.position;
        tempSnowBall.transform.rotation = Quaternion.LookRotation(targetDirection);
        tempSnowBall.SetActive(true);

        // Get the Rigidbody component of the snowball
        Rigidbody tempRb = tempSnowBall.GetComponent<Rigidbody>();
        if (tempRb != null)
        {
            // Apply force towards the player
            tempRb.AddForce(targetDirection * throwSpeed, ForceMode.Impulse);
            Debug.Log("Snowball thrown towards player!");
        }
        else
        {
            Debug.LogError("Rigidbody component missing on snowball!");
            justThrown = false;
            return;
        }

        // Reset justThrown after a delay
        StartCoroutine(ResetThrownStatus());
    }

    IEnumerator ResetThrownStatus()
    {
        yield return new WaitForSeconds(0.1f);
        justThrown = false;
    }
}
