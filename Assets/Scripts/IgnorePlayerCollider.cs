using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCollider : MonoBehaviour
{
    private Rigidbody2D rb;

    public CapsuleCollider2D playerCollider;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreCollision(playerCollider, GetComponent<Collider2D>());
    }
}
