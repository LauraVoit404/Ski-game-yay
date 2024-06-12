using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; // The prefab to be pooled
    public int initialPoolSize = 10; // Number of objects to initially pool
    public int refillAmount = 5; // Number of objects to add when pool runs out

    private List<GameObject> objectPool = new List<GameObject>();

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        // Populate the object pool
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // If no inactive objects are found, refill the pool
        RefillPool(refillAmount);

        // Try to retrieve an object again
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // If still no inactive objects are found, return null
        return null;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void RefillPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }
}
