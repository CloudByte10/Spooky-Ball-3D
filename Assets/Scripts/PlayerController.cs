using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 8f;
    public float jumpHeight = 1.5f;
    public float groundDist = 0.2f;
    public float gravity = -9.81f;

    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundMask;
    
    private Vector3 moveDirection;
    private Vector3 velocity;
    
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        //HealthBarController.SetHealthValue(.2f);
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){
        // Determine if char is in the air by checking distance between char and ground mask
        isGrounded = Physics.CheckSphere(transform.position, groundDist, groundMask);

        // Set front/back and left/right controls
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(-moveX, 0, -moveZ);

         if(isGrounded && velocity.y < 0){
             velocity.y = -2f;
         }

        if(isGrounded){ // Prevents double jumping
            moveDirection *= walkSpeed;

            if(Input.GetKeyDown(KeyCode.Space)){
                Jump();
            }
        }

        // Set controller to move
        controller.Move(moveDirection * walkSpeed * Time.deltaTime );

        // Bring character back to ground
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump(){
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
