﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPhysics : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMovement = 0f;
    private bool jump;
    private bool grounded;
    private Transform groundCheck;
    const float groundedRadius = .2f;

    public float moveSpeed;
    [SerializeField] private LayerMask whatIsGround;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    public float jumpForce;

    private Vector3 m_Velocity = Vector3.zero;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKey("space");
    }

    private void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }

        Move(horizontalMovement, jump);
    }

    private void Move(float movementDirection, bool jump)
    {
        // Achando a velocidade desejada
        Vector3 targetVelocity = new Vector2(movementDirection * Time.fixedDeltaTime*100 * moveSpeed, rb.velocity.y);
        // Suavizando o movimento e aplicando no personagem
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, movementSmoothing);

        if (jump && grounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce*100));
        }
    }

}
