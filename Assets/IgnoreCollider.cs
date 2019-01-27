using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour
{
    public void IgnoreThisCollider(CapsuleCollider2D playerCollider)
    {
        Physics2D.IgnoreCollision(playerCollider, GetComponent<CircleCollider2D>());
    }

}
