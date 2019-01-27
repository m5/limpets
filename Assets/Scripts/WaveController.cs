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
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("wave collieded with: " + collision.gameObject.tag);
    }
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "penguin")
        {
            collider.gameObject.GetComponent<PlayerController>().OnGetWet();
        }
        Debug.Log("wave triggered with: " + collider.gameObject.tag);
    }

}
