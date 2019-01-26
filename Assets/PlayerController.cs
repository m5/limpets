using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public UnityEngine.AI.NavMeshAgent agent;
    private bool firstUpdateRan = false;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Animator anim = GetComponent<Animator>();
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        anim.Play("walk", -1, Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstUpdateRan)
        {
            agent.SetDestination(transform.position + new Vector3(0.001f, 0, 0));
            firstUpdateRan = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                
            }
        }

    }
}
