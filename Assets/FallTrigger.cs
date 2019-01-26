using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public GameObject fallingObject;
    private bool makeItFall;

    public void OnTriggerEnter(Collider c)
    {
        Debug.Log("something landed on the iceberg");
        makeItFall = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (makeItFall) { 
            fallingObject.transform.Translate(new Vector3(0,0,-1) * Time.deltaTime);
        }
    }
}
