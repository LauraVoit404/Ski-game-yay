using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public Text timeCounter;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps the instance between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Ensure UI references are updated when the scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Initialize the timer display
        if (timeCounter == null)
        {
            FindTimeCounter();
        }

        if (timeCounter != null)
        {
            timeCounter.text = "Time: 00:00.0";
        }
        timerGoing = false;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindTimeCounter();
    }

    private void FindTimeCounter()
    {
        timeCounter = GameObject.Find("TimerText")?.GetComponent<Text>();
    }

    public void BeginTimer()
    {
        Debug.Log("Timer started");
        timerGoing = true;
        elapsedTime = 0f;
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        Debug.Log("Timer ended");
        timerGoing = false;

        // Add the final time to the leaderboard
        Leaderboard leaderboard = FindObjectOfType<Leaderboard>();
        if (leaderboard != null)
        {
            leaderboard.AddTime(elapsedTime);
        }
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            if (timeCounter != null)
            {
                timeCounter.text = timePlayingStr;
            }

            yield return null;
        }
    }

    public void AddPenaltyTime(float penalty)
    {
        elapsedTime += penalty;
        Debug.Log($"Penalty of {penalty} seconds added. New time: {TimeSpan.FromSeconds(elapsedTime).ToString("mm':'ss'.'ff")}");
    }
}
