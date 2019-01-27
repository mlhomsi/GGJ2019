using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowPlatform : MonoBehaviour
{
    private bool hasThrown;         // If the player has thrown a see recent
    private Transform throwTransform;
    private Vector2 myPos;
    private Quaternion rotation;
    private GameObject projectile;

    public GameObject seed_static;
    public GameObject seed_jumpPad;

    public Vector3 offset = new Vector3(0f, 0f, 0f);
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        throwTransform = transform.GetChild(1);
    }

    void Update()
    {

        myPos = new Vector2(throwTransform.position.x, throwTransform.position.y);
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            PrepareThrow();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ThrowSeed(seed_static);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            // ThrowSeed(seed_jumpPad);
            hasThrown = false;
        }        
    }

    // Saves the direction the player is aiming the seed
    Vector3 direction;
    private void PrepareThrow()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3
            (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        
        direction = 10 * (target - Camera.main.transform.localPosition);
        Vector3.Normalize(direction);
        rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);
    }

    // Throws the seed in the direction the player has aimed at, determined by "PrepareThrow"
    private void ThrowSeed(GameObject seed)
    {
        if (!hasThrown)
        {
            projectile = (GameObject)Instantiate(seed, myPos, rotation);

            // Stops the projectile so as to not get the player's speed
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
            // Adds the expected projectile speed
            projectile.GetComponent<Rigidbody2D>().velocity = direction * power;
            hasThrown = true;
        }
    }
}
