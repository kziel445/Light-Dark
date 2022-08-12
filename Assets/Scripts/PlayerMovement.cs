using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;
    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource footStep;
    public float speed = 40f;

    float horizontalMove;
    float verticalMove;

    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
        rb = GetComponent<Rigidbody2D>();
        footStep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (horizontalMove != 0) animator.SetBool("Running", true);
        else animator.SetBool("Running", false);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        if(controller.m_Grounded) animator.SetBool("InAir", false);
        else animator.SetBool("InAir", true);
    }
    public void FootStep()
    {
        footStep.Play();
    }
}
