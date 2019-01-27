using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagControler : MonoBehaviour
{
    Quaternion V = Quaternion.identity;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition + new Vector3 (x: 0 , y:  0, z: 100));
            var layerMask = (1 << Physics.IgnoreRaycastLayer);
            layerMask = ~layerMask;
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                transform.position = hit.point; 

            }
        }
    }
}