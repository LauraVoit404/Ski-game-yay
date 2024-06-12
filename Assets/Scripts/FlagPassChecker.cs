using UnityEngine;

public class FlagPassChecker : MonoBehaviour
{
    public enum FlagType { Blue, Pink }
    public FlagType flagType;
    private Transform flagTransform;

    private void Start()
    {
        flagTransform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 playerPosition = other.transform.position;
            Vector3 flagPosition = flagTransform.position;

            bool passedCorrectSide = false;

            if (flagType == FlagType.Blue)
            {
                passedCorrectSide = playerPosition.x < flagPosition.x; // Player should be on the left of the flag
            }
            else if (flagType == FlagType.Pink)
            {
                passedCorrectSide = playerPosition.x > flagPosition.x; // Player should be on the right of the flag
            }

            if (!passedCorrectSide)
            {
                // Add 1 second penalty
                TimerController.instance.AddPenaltyTime(1.0f);
                Debug.Log("Penalty applied for passing on the wrong side!");
            }
        }
    }
}
