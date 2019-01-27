using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PenguinManager;

public class CameraScript : MonoBehaviour
{
    //public Vector3 offset = new Vector3(0, 0, -1);

    float averageX;
    float averageZ;

    // Update is called once per frame
    void Update()
    {
        float totalX = 0;
        float totalZ = 0;
        float total = 0;

        for (int i = 0; i < PenguinManager.PenguinManager.numberOfPenguins; i++)
        {
            GameObject penguin = PenguinManager.PenguinManager.penguins[i];
            if (penguin.GetComponent<PlayerController>().status == "dry")
            {
                totalX += penguin.transform.position.x;
                totalZ += penguin.transform.position.z;
                total += 1;
            }
        }

        if (total > 0)
        {
            averageX = totalX / total ;
            averageZ = totalZ / total;
            transform.position = new Vector3(averageX, 0, averageZ);
        }
    }
}

