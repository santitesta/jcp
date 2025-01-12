using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text goalText; // Reference to the UI Text object
    public FieldBoundaryReset FieldBoundaryReset; // Reference to the reset script

    public void ShowGoalPopup()
    {
        // Show the GOAL message
        goalText.gameObject.SetActive(true);

        // Hide the GOAL message after 2 seconds
        Invoke("HideGoalPopup", 2f);

        // Reset the ball and players after 2 seconds
        Invoke("ResetGame", 2f);
    }

    private void HideGoalPopup()
    {
        goalText.gameObject.SetActive(false);
    }

    private void ResetGame()
    {
        FieldBoundaryReset.ResetPositions(); // Call the reset method
    }
}
