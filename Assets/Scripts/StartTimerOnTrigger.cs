using UnityEngine;

public class StartTimerOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimerController.instance.BeginTimer();
        }
    }
}
