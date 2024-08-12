using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; 
    public float rotationSpeed = 10f; 
    public Camera playerCamera; 
    private CharacterController controller;
    private Vector3 movementDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
     
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = playerCamera.transform.TransformDirection(direction);
        direction.y = 0f; 

      
        direction.Normalize();

       
        controller.Move(direction * speed * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
