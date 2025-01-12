using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50f; // Speed of horizontal movement
    public float jumpForce = 50f; // Force applied when jumping

    private Rigidbody2D rb;
    private bool isGrounded = true; // Check if the player is on the ground

    public string playerType = "Player1"; // Set this to "Player1" or "Player2" in the Inspector

    // References to legs
    public Transform leftLeg;
    public Transform rightLeg;

    public float rotationSpeed = 200f; // Speed of rotation for the legs
    private bool isLeftLegMoving = false; // Tracks if left leg is moving

    private float leftLegTargetAngle = 0f; // Target angle for the left leg

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveDirection = 0;

        if (playerType == "Player1")
        {
            // Movement for Player 1 (A and D)
            if (Input.GetKey(KeyCode.A)) moveDirection = -1;
            if (Input.GetKey(KeyCode.D)) moveDirection = 1;

            // Jump for Player 1 (W)
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                Jump();
            }

            // Rotate Left Leg for Player 1 (E key)
            if (Input.GetKey(KeyCode.E))
            {
                isLeftLegMoving = true;
                leftLegTargetAngle = 90f; // Move leg upward
            }
            else
            {
                isLeftLegMoving = false;
                leftLegTargetAngle = 0f; // Return leg to default position
            }
        }
        else if (playerType == "Player2")
        {
            // Movement for Player 2 (Left and Right Arrows)
            if (Input.GetKey(KeyCode.LeftArrow)) moveDirection = -1;
            if (Input.GetKey(KeyCode.RightArrow)) moveDirection = 1;

            // Jump for Player 2 (Up Arrow)
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                Jump();
            }

            // Rotate Right Leg for Player 2 (Right Shift key)
            if (Input.GetKey(KeyCode.RightShift))
            {
                isLeftLegMoving = true;
                leftLegTargetAngle = 90f; // Move leg upward
            }
            else
            {
                isLeftLegMoving = false;
                leftLegTargetAngle = 0f; // Return leg to default position
            }
        }

        // Apply horizontal movement
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);

        // Smoothly rotate the left leg based on target angle
        RotateLeg(leftLeg, leftLegTargetAngle);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false; // Player is no longer grounded after jumping
    }

    void RotateLeg(Transform leg, float targetAngle)
    {
        // Smoothly rotate the leg toward the target angle
        float currentAngle = Mathf.LerpAngle(leg.localEulerAngles.z, targetAngle, Time.deltaTime * rotationSpeed / 100f);
        leg.localEulerAngles = new Vector3(0, 0, currentAngle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is touching the floor
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}
