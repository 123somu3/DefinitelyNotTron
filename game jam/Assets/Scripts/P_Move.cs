using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Move : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    private Camera mainCamera;

    public CharacterController Controller;
    private Vector3 velocity;
    public bool isGrounded;

    public bool collectedJum;
    internal float movedir;
    internal object controller;

    void Start()
    {
        mainCamera = Camera.main;
        collectedJum = false;
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();

        if (collectedJum)
        {
            Jump();
        }

    }




    void Move()
    {

        isGrounded = Controller.isGrounded;
        //if (isGrounded && velocity.y < 0)
        //{
        //    velocity.y = 0;
        //}


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;


        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        //gravity
        move.y += gravity * Time.deltaTime;

        Controller.Move(move * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        Controller.Move(velocity * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("jumpcollection"))
        {
            collectedJum = true;
            Destroy(other.gameObject);
        }
    }

    private void CameraRelaitaveMovement(float x, float y)
    {
        //Split vector
        Vector3 fwd = mainCamera.transform.forward;
        Vector3 bck = mainCamera.transform.position;
        //multiply input
        //make vector
        //apply vector
    }
}
