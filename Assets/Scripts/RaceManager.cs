using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    public static RaceManager Instance { get; private set; }
    public int TotalRaces { get; private set; }
    public Text TimerText;
    public Text LeaderboardText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementRaces()
    {
        TotalRaces++;
    }

    // Method to update UI references
    public void UpdateUIReferences()
    {
        TimerText = GameObject.Find("TimerText")?.GetComponent<Text>();
        LeaderboardText = GameObject.Find("LeaderboardText")?.GetComponent<Text>();
    }
}
