
using UnityEngine;

public class WaterColision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("penguine is wet.");
    }
}
