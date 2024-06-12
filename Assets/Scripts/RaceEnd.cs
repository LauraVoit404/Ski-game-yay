using UnityEngine;
using UnityEngine.UI;
public class RaceEnd : MonoBehaviour
{
    public Leaderboard leaderboard;
    public RaceTimer raceTimer;

    public void EndRace()
    {
        raceTimer.StopTimer();
        float raceTime = raceTimer.GetRaceTime();
        RaceManager.Instance.IncrementRaces();
        leaderboard.AddTime(raceTime);
    }
}
