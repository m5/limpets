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

        for (int i = 0; i < PenguinManager.PenguinManager.numberOfPenguins; i++)
        {
            totalX += PenguinManager.PenguinManager.penguins[i].transform.position.x;
            totalZ += PenguinManager.PenguinManager.penguins[i].transform.position.z;
        }

        averageX = totalX / PenguinManager.PenguinManager.numberOfPenguins;
        averageZ = totalZ / PenguinManager.PenguinManager.numberOfPenguins;

        transform.position = new Vector3( averageX, 0, averageZ);
    }
}

