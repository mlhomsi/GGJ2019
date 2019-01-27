using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillChar : MonoBehaviour
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
    		Debug.Log("Era pra morrer");
    		col.transform.position = col.gameObject.GetComponent<PlayerCheckpoint>().currentCheckpoint.transform.position;
    	}

    	if (col.gameObject.CompareTag("Ghost"))
    	{
    		col.transform.position = col.gameObject.GetComponent<GhostCheckpoint>().spawnPoint.transform.position;
    	}
    }

}
