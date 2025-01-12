using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager gameManager; // Reference to GameManager for showing the pop-up

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            gameManager.ShowGoalPopup(); // Trigger the "Goal" message
        }
    }
}