using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    public float transitionTime = 0.2f;



    public Animator animator;
    private Vector2 currentInput;
    void Start()
    {
        animator.SetFloat("H", 0);
        animator.SetFloat("V", 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 delante = camaraPrincipal.transform.forward * Input.GetAxis("Vertical");
        Vector3 derecha = camaraPrincipal.transform.right * Input.GetAxis("Horizontal");
        delante.y = 0.0f; derecha.y = 0.0f;
        Vector3 vectorInput = delante + derecha;
        if (vectorInput.magnitude > 1)
        { vectorInput = vectorInput.normalized; }*/


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");



        Vector2 targetInput = new Vector2(moveHorizontal, moveVertical);
        currentInput = Vector2.Lerp(currentInput, targetInput, Time.deltaTime / transitionTime);



        animator.SetFloat("H", currentInput.x);
        animator.SetFloat("V", currentInput.y);
    }
}
