using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPhysics : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMovement = 0f;
    private bool jump;

    public float moveSpeed;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    public float jumpForce;

    private Vector3 m_Velocity = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKeyDown("space");
    }

    private void FixedUpdate()
    {
        Move(horizontalMovement, jump);
    }

    private void Move(float movementDirection, bool jump)
    {
        // Achando a velocidade desejada
        Vector3 targetVelocity = new Vector2(movementDirection * moveSpeed, rb.velocity.y);
        // Suavizando o movimento e aplicando no personagem
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, movementSmoothing);

        if (jump)
        {
            rb.AddForce(new Vector2(0f, jumpForce*100));
        }
    }

}
