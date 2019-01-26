using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinManager : MonoBehaviour
{
    public GameObject penguin;
    [SerializeField]
    public int numberOfPenguins;

    private List<GameObject> penguins = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < numberOfPenguins; i++)
        {
            penguins.Add(Instantiate(penguin, penguin.transform.position, penguin.transform.rotation));
        }
        Debug.Log("all the penguins" + penguins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
