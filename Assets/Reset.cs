using UnityEngine;

public class FieldBoundaryReset : MonoBehaviour
{
    public Transform ball; // Reference to the ball
    public Transform[] players; // References to the players

    public Vector2 ballStartPosition; // Starting position of the ball
    public Vector2[] playerStartPositions; // Starting positions of the players

    public bool[] playersOutOfBounds; // Tracks whether each player is out of bounds

    void Start()
    {
        // Save initial positions of ball and players
        ballStartPosition = ball.position;

        playerStartPositions = new Vector2[players.Length];
        playersOutOfBounds = new bool[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            playerStartPositions[i] = players[i].position;
            playersOutOfBounds[i] = false; // Initialize all players as in-bounds
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            // If the ball exits, reset positions immediately
            ResetPositions();
        }
        else
        {
            // Check if a player exited the field
            for (int i = 0; i < players.Length; i++)
            {
                if (collision.transform == players[i])
                {
                    playersOutOfBounds[i] = true;
                    CheckAllPlayersOut();
                    return;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Reset the player's out-of-bounds status when they return
        for (int i = 0; i < players.Length; i++)
        {
            if (collision.transform == players[i])
            {
                playersOutOfBounds[i] = false;
                return;
            }
        }
    }

    void CheckAllPlayersOut()
    {
        // Check if all players are out of bounds
        foreach (bool isOut in playersOutOfBounds)
        {
            if (!isOut)
            {
                return; // At least one player is still in-bounds
            }
        }

        // If all players are out, reset positions
        ResetPositions();
    }

    public void ResetPositions()
    {
        // Reset the ball's position
        ball.position = ballStartPosition;
        ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero; // Stop any movement

        // Reset players' positions
        for (int i = 0; i < players.Length; i++)
        {
            players[i].position = playerStartPositions[i];
            players[i].GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero; // Stop movement
            playersOutOfBounds[i] = false; // Mark them as back in-bounds
        }

        Debug.Log("Positions reset!");
    }
}
