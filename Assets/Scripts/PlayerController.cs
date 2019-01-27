using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PenguinManager;

public class PlayerController : MonoBehaviour
{
    public PenguinManager.PenguinManager penguinManager;
    public Camera cam;
    public string status = "dry";
    public UnityEngine.AI.NavMeshAgent agent;
    public bool useNavMesh = true;
    private Rigidbody rigidbody;
    [SerializeField] AudioClip[] penguinSounds;

    private float maxSpeed = 0;

    AudioSource myAudioSource;

    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        status = "dry";
        agent.enabled = useNavMesh;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = useNavMesh;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.3 && status != "wet")
        {
            //penguin yells
            AudioClip clip = penguinSounds[UnityEngine.Random.Range(0, penguinSounds.Length)];
            myAudioSource.pitch = UnityEngine.Random.Range(1.4f, 1.6f);
            myAudioSource.PlayOneShot(clip);

            status = "wet";
            if (useNavMesh)
            {
                status = "wet";
                if (useNavMesh)
                {
                    agent.SetDestination(GameObject.Find("Losers").transform.position);
                }
                penguinManager.wetCount++;
            }
            GetComponentsInChildren<Transform>()[1].localEulerAngles = new Vector3(0, 90, 60);
        }
        else
        {
            GetComponentsInChildren<Transform>()[1].localEulerAngles = new Vector3(0, 90, 0);
        }

        if (Input.GetMouseButtonDown(0) && status != "wet")
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            var layerMask = (1 << Physics.IgnoreRaycastLayer);
            layerMask = ~layerMask;
            RaycastHit hit;
           
            if(Physics.Raycast(ray, out hit))
            {
                if (useNavMesh) 
                {
                    agent.SetDestination(hit.point);
                }
                else
                {
                    destination = hit.point;
                }
            }

        }
        if (transform.position.z > 0.5 && status != "wet")
        {
            penguinManager.finishCrossCount++;
        }

        if (destination != Vector3.zero && status != "wet" && !useNavMesh)
        {
            Vector3 diff = destination - transform.position;
            //Vector3 force = Vector3.MoveTowards(transform.position, destination, Time.fixedDeltaTime);
            //force.y = 0;

            float speed = 1; // Vector3.Magnitude(diff);
            //maxSpeed = speed + 0.1f;
            diff.y = 0;
            //transform.position += diff * speed * Time.fixedDeltaTime;
            transform.forward = Vector3.RotateTowards(transform.forward, diff, 4 * Time.fixedDeltaTime, 4 * Time.fixedDeltaTime);
            rigidbody.AddForce(diff * speed * 10 * Time.fixedDeltaTime, ForceMode.VelocityChange);//, ForceMode.VelocityChange);
        }
    }

    public void OnWaveHit()
    {
        Debug.Log("penguin hit by wave!");
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collieded with: " + collision.gameObject.tag);
    }
    void FixedUpdate()
    {

    }
}
