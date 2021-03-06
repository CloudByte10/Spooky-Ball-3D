using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 8f;
    public float rotateSpeed = 500f;
    public float jumpHeight = 1.5f;
    public float groundDist = 0.2f;
    public float gravity = -9.81f;

    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Camera mainCam;
    
    private Vector3 moveDirection;
    private Vector3 velocity;
    
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        //HealthBarController.SetHealthValue(.2f);
        controller = GetComponent<CharacterController>(); 
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }

    private void Move(){

        // Determine if char is in the air by checking distance between char and ground mask
        isGrounded = Physics.CheckSphere(transform.position, groundDist, groundMask);

        // Set front and back controls
        float moveZ = Input.GetAxis("Vertical") * walkSpeed;

        Vector3 camRightFlat = new Vector3(mainCam.transform.right.x, 0f, mainCam.transform.right.z).normalized;
        Vector3 camForwardFlat = new Vector3(mainCam.transform.forward.x, 0f, mainCam.transform.forward.z).normalized;

        controller.Move((camForwardFlat  * moveZ) * Time.deltaTime);       

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -10f;
        }

        if(isGrounded){ // Prevents double jumping
            moveDirection *= walkSpeed;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        if(transform.position.y < -100)
        {
            // Scene fell = SceneManager.GetActiveScene();
            SceneManager.LoadScene("DeathScreen");
        }

        // Bring character back to ground
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void Rotate()
    {
        // Use A and D as rotation keys
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime * 70, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime * 70, 0, Space.World);
        }
    }
}
