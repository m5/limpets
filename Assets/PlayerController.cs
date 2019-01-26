using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PenguinManager;

public class PlayerController : MonoBehaviour
{
    public PenguinManager.PenguinManager penguinManager;
    public Camera cam;
    string status = "dry";
    public UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        string status = "dry";
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.3 && status != "wet")
        {
            status = "wet";
            agent.Stop();
            penguinManager.wetCount++;
        }
    
        if (Input.GetMouseButtonDown(0) && status != "wet")
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                
            }

        }
        if (transform.position.z > 0.5)
        {
            penguinManager.finishCrossCount++;
        }
        

    }
}
