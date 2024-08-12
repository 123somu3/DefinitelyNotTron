using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;      // The speed during the dash
    public float dashDuration = 0.2f;  // How long the dash lasts
    public float dashCooldown = 1f;    // How long before the player can dash again

    private bool isDashing = false;    // To check if the player is currently dashing
    private bool canDash = true;       // To check if the player can dash
    private Vector3 dashDirection;     // The direction in which the player will dash

    private CharacterController controller; // Reference to the CharacterController component

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Initialize the CharacterController
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        canDash = false; // Prevent the player from dashing again immediately
        isDashing = true;

        float startTime = Time.time;

        // Store the current movement direction
        dashDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (dashDirection == Vector3.zero)
        {
            dashDirection = transform.forward; // Dash forward if no input direction is given
        }

        while (Time.time < startTime + dashDuration)
        {
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
            yield return null;
        }

        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true; // Allow the player to dash again after the cooldown
    }
}
