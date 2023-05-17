using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;

public class ControlPlayer2 : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;
    public CharacterController player;
    public float playerSpeed;
    private Vector3 movePlayer;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    public float transitionTime = 0.2f;
    private Vector2 currentInput;
    public Animator animator;
    public float gravity = -9.81f;
    private float fallingVelocity = 0;
    public float jumpSpeed = 20;
    public float jumpHeight = 1.5f;
    private Vector3 velocity;
    //private MovingPlatform platform = null;


    // Use this for initialization
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float jump = 0;
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        Vector2 targetInput = new Vector2(horizontalMove, verticalMove);
        currentInput = Vector2.Lerp(currentInput, targetInput, Time.deltaTime / transitionTime);

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        animator.SetFloat("H", currentInput.x);
        animator.SetFloat("V", currentInput.y);

        CamDirection();

        /*Vector3 pScale = Vector3.one;
        if (platform != null)
        {
            transform.parent = platform.transform;
            pScale = platform.transform.localScale;
        }
        else
        {
            transform.parent = null;
        }*/
        //Apply gravity
        if (player.isGrounded)
        {
            animator.SetBool("Fall", false);
            fallingVelocity= 0;
            velocity.y = -2f;
        }
        else if(!player.isGrounded && !animator.GetBool("Jump"))
        {
            animator.SetBool("Fall", true);
            //fallingVelocity += gravity * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
        }

        if(player.isGrounded && Input.GetButtonDown("Jump"))
        {
            //jump = jumpSpeed;
            animator.SetBool("Jump", true);
            //jump = Mathf.Sqrt(jumpHeight * -2 * gravity);
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        //Vector3 gravityVector = new Vector3(0, fallingVelocity + jump, 0);
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        
        player.gameObject.transform.forward = Vector3.Lerp(player.transform.forward, movePlayer, 15f*Time.deltaTime);
        
        player.Move(movePlayer * playerSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        player.Move(velocity * Time.deltaTime);

        Debug.Log(player.velocity.magnitude);
    }
    //Funcion para determinar la direccion a la que mira la camara.  
    public void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    public void playerFall()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Fall", true);
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform") && player.isGrounded)
        {
            platform = collision.gameObject.GetComponent<MovingPlatform>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            platform = null;
        }
    }*/
}
