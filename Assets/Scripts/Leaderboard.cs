using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    private List<float> bestTimes = new List<float>();
    private const string BestTimesKey = "BestTimes";
    public Text leaderboardText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Keep this object between scenes
    }

    private void Start()
    {
        // Ensure UI references are updated when the scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Load best times from PlayerPrefs
        LoadBestTimes();

        // Update leaderboard UI
        UpdateLeaderboardUI();
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindLeaderboardText();
        UpdateLeaderboardUI();
    }

    private void FindLeaderboardText()
    {
        leaderboardText = GameObject.Find("LeaderboardText")?.GetComponent<Text>();
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        if (bestTimes.Count > 5)
        {
            bestTimes.RemoveAt(bestTimes.Count - 1);
        }
        SaveBestTimes();
        UpdateLeaderboardUI();
    }

    private void SaveBestTimes()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(BestTimesKey + i, bestTimes.Count > i ? bestTimes[i] : float.MaxValue);
        }
        PlayerPrefs.Save();
    }

    private void LoadBestTimes()
    {
        bestTimes.Clear();
        for (int i = 0; i < 5; i++)
        {
            float time = PlayerPrefs.GetFloat(BestTimesKey + i, float.MaxValue);
            if (time != float.MaxValue)
            {
                bestTimes.Add(time);
            }
        }
        bestTimes.Sort();
    }

    private void UpdateLeaderboardUI()
    {
        if (leaderboardText != null)
        {
            leaderboardText.text = "Best Times:\n";
            for (int i = 0; i < bestTimes.Count; i++)
            {
                leaderboardText.text += $"{i + 1}. {bestTimes[i]:F2} seconds\n";
            }
        }
    }
}
