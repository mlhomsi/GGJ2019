using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.gameObject.CompareTag("Player"))
    	{
    		col.gameObject.GetComponent<PlayerCheckpoint>().currentCheckpoint = gameObject;
    	}
    }
}
