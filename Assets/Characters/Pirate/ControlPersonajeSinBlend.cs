using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonajeSinBlend : MonoBehaviour
{
    public Animator animator;
    public CharacterController characterController;
    public float speed = 10;
    public float rootSpeed = 180;
    public Camera camaraPrincipal;
    public Vector3 vectorInput;
    public enum PlayerStates
    {
        IDLE,
        RUN,
        JUMP,
        PUNCH,
        DYING
    }
    [SerializeField]
    PlayerStates state = PlayerStates.IDLE;
    void Start()
    {
        state = PlayerStates.IDLE;
        animator.SetInteger("State", (int)PlayerStates.IDLE);
        //animator.SetFloat("PosX", 0);
        //animator.SetFloat("PosY", 0);
    }

    // Update is called once per frame
    void Update()
    {
        /* float horizontalMovement = Input.GetAxis("Horizontal");
         float verticalMovement = Input.GetAxis("Vertical");
         Vector3 rotation = new Vector3(0, horizontalMovement * 180 * Time.deltaTime, 0);
         Vector3 move = new Vector3(0, 0, verticalMovement);
         move = this.transform.TransformDirection(move);
         characterController.Move(move*speed);   
         this.transform.Rotate(rotation);*/

        Vector3 delante = camaraPrincipal.transform.forward * Input.GetAxis("Vertical");
        Vector3 derecha = camaraPrincipal.transform.right * Input.GetAxis("Horizontal");
        delante.y = 0.0f; derecha.y = 0.0f;
        vectorInput = delante + derecha;
        if (vectorInput.magnitude > 1)
        { vectorInput = vectorInput.normalized; }
        Vector3 direccionObjetivo = vectorInput * speed;
        Vector3 direccion = Vector3.RotateTowards(this.transform.forward, direccionObjetivo, rootSpeed * Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.R))
        {
            MatarPersonaje();
        }
        /*Vector3 direccionObjetivo = vectorInput * speed;
        Vector3 direccion = Vector3.RotateTowards(this.transform.forward, direccionObjetivo, speed * Time.deltaTime, 0);
        this.transform.rotation = Quaternion.LookRotation(direccion);
        //this.transform.Rotate(direccion);
        this.characterController.Move(direccionObjetivo);*/

        switch (state)
        {
            case PlayerStates.IDLE:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    state = PlayerStates.PUNCH;
                    animator.SetInteger("State", (int)PlayerStates.PUNCH);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    state = PlayerStates.JUMP;
                    animator.SetInteger("State", (int)PlayerStates.JUMP);
                }
                else if (vectorInput.x != 0 && vectorInput.z != 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        state = PlayerStates.JUMP;
                        animator.SetInteger("State", (int)PlayerStates.JUMP);
                    }
                    else
                    {
                        state = PlayerStates.RUN;
                        animator.SetInteger("State", (int)PlayerStates.RUN);
                    }
                    //state = PlayerStates.RUN;
                    
                    this.transform.rotation = Quaternion.LookRotation(direccion);
                    //this.transform.Rotate(direccion);
                    this.characterController.Move(direccionObjetivo);
                    
                    //animator.SetFloat("PosX", 1);
                    //animator.SetFloat("PosY", 0);
                }
                break;
            case PlayerStates.RUN:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    state= PlayerStates.PUNCH;
                    animator.SetInteger("State", (int)PlayerStates.PUNCH);
                }
                else if (vectorInput.x == 0 && vectorInput.z == 0)
                {
                    state = PlayerStates.IDLE;
                    animator.SetInteger("State", (int)PlayerStates.IDLE);
                    //animator.SetFloat("PosX", 0);
                    //animator.SetFloat("PosY", 0);
                }
                else
                {
                    this.transform.rotation = Quaternion.LookRotation(direccion);
                    //this.transform.Rotate(direccion);
                    this.characterController.Move(direccionObjetivo);
                    if(Input.GetKeyDown(KeyCode.Space))
                    {
                        state = PlayerStates.JUMP;
                        animator.SetInteger("State", (int)PlayerStates.JUMP);
                    }
                }
                break;
            case PlayerStates.PUNCH:
                break;
            case PlayerStates.JUMP:
                this.transform.rotation = Quaternion.LookRotation(direccion);
                //this.transform.Rotate(direccion);
                this.characterController.Move(direccionObjetivo);
                break;
            case PlayerStates.DYING:
                animator.SetInteger("State", (int)(PlayerStates.DYING));
                break;

        }
    }

    public void MatarPersonaje()
    {
        state = PlayerStates.DYING;
        animator.SetInteger("State", (int)state);
    }

    public void IdleReturn()
    {
        state = PlayerStates.IDLE;
        animator.SetInteger("State", (int)PlayerStates.IDLE);
    }
}
