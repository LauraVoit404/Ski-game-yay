using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    private float raceTime;
    private bool raceActive;

    private void Start()
    {
        raceActive = true;
        raceTime = 0f;
        UpdateTimerText();
    }

    private void Update()
    {
        if (raceActive)
        {
            raceTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        if (RaceManager.Instance.TimerText != null)
        {
            RaceManager.Instance.TimerText.text = raceTime.ToString("F2");
        }
    }

    public void StopTimer()
    {
        raceActive = false;
    }

    public float GetRaceTime()
    {
        return raceTime;
    }
}
