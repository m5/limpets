using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform Target;
    public Vector3 offset = new Vector3(0, 0, -1);

    void LateUpdate()
    {
        //transform.position = Target.position + offset;
    }
}

