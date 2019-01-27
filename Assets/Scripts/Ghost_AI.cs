using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_AI : MonoBehaviour
{
    private Rigidbody2D rb;
    //private float horizontalMovement = 0f;

    public float moveSpeed;
    public bool walkRight;
    public CapsuleCollider2D playerCollider;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;

    private Vector3 m_Velocity = Vector3.zero;
    public bool playerTrigger = false;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!walkRight)
        	Flip();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalMovement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
    	if (playerTrigger)
    	{
	    	if (walkRight)
	        	Move(1);
	        else
	        	Move(-1);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    	if (col.gameObject.CompareTag("Wall")) 
    	{
    		Flip();
    		if (walkRight)
    			walkRight = false;
    		else
    			walkRight = true;
    	}

    	if (col.gameObject.CompareTag("Player"))
    	{
    		playerTrigger = true;
    		GetComponent<AudioSource>().Play();
    		Physics2D.IgnoreCollision(playerCollider, GetComponent<Collider2D>());
    	}
    }

    private void Move(float movementDirection)
    {
        // Achando a velocidade desejada
        Vector3 targetVelocity = new Vector2(movementDirection * Time.fixedDeltaTime*100 * moveSpeed, rb.velocity.y);
        // Suavizando o movimento e aplicando no personagem
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
    }

    void Flip(){
         Vector3 theScale = transform.localScale;
         theScale.x *= -1;
         transform.localScale = theScale;

     }
}
