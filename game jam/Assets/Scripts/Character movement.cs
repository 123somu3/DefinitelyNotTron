using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset velocity if grounded
        }

        // Get input from the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Move the character
        controller.Move(move * speed * Time.deltaTime);

        // Jump logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Move the character downward based on gravity
        controller.Move(velocity * Time.deltaTime);
    }
}
