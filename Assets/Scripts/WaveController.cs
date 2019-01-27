using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int period = 5;
    private float elapsedSinceInit;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        elapsedSinceInit += Time.fixedDeltaTime;
        if (elapsedSinceInit > period)
        {
            transform.position = initialPosition;
            elapsedSinceInit = 0;
        }
        else
        {
            transform.position = transform.position + new Vector3(-1, 0, 0) * Time.fixedDeltaTime * 10;
        }
    }
    
}
