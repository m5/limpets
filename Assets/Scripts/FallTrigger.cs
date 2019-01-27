using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public GameObject fallingObject;
    private bool makeItFall;

    public void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "penguin")
        {
            makeItFall = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (makeItFall) {
            fallingObject.transform.Translate(new Vector3(0,0,-0.2f) * Time.deltaTime * 2);
        }
    }
}
