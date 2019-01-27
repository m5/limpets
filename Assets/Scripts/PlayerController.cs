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
    public Rigidbody rigidbody;

    private float maxSpeed = 0;

    private Vector3 destination;
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
            //agent.Stop();
            penguinManager.wetCount++;
        }
    
        if (Input.GetMouseButtonDown(0))// && status != "wet")
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           
            if(Physics.Raycast(ray, out hit))
            {
                //agent.SetDestination(hit.point);
                destination = hit.point;
                
            }

        }
        if (transform.position.z > 0.5)
        {
            penguinManager.finishCrossCount++;
        }

        if (destination != Vector3.zero)// && status != "wet")
        {
            Vector3 diff = destination - transform.position;
            //Vector3 force = Vector3.MoveTowards(transform.position, destination, Time.fixedDeltaTime);
            //force.y = 0;

            float speed = Mathf.Min(Mathf.Min(0.5f, maxSpeed), Vector3.Magnitude(diff));
            maxSpeed = speed + 0.01f;
            diff.y = 0;
            transform.position += diff * speed * Time.fixedDeltaTime;
            transform.forward = Vector3.RotateTowards(transform.forward, diff, 4 * Time.fixedDeltaTime, 4 * Time.fixedDeltaTime);
            //rigidbody.AddForce(diff * scale * Time.fixedDeltaTime, ForceMode.VelocityChange);//, ForceMode.VelocityChange);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collieded with: " + collision.gameObject.tag);
    }
    void FixedUpdate()
    {
       
    }
}
