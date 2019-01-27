using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaProcessingTest : MonoBehaviour
{

    public GameObject player;
    public GameObject postprocessing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > 55f)
        {
           // Debug.Log(player.transform.position.x);

        }

    }
}
