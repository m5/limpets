using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    public AudioClip Background;
    public AudioSource audioBackground;

    // Start is called before the first frame update
    void Start()
    {
        audioBackground.clip = Background;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) //add in cue action instead of true.
        {
            audioBackground.Play();
        }
    }
}
