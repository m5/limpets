﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PenguinManager
{
    public class PenguinManager : MonoBehaviour
    {
        public GameObject penguin;
        [SerializeField]
        public static int numberOfPenguins = 9;
        public static GameObject[] penguins;
        public int wetCount = 0;
        public int finishCrossCount;
        public GameObject successText;
        public GameObject failText;
        public GameObject continueButton;
        private bool levelComplete = false;

        [SerializeField] AudioClip winSound;
        [SerializeField] AudioClip loseSound;
        AudioSource myAudioSource;

        // Start is called before the first frame update
        void Start()
        {
            penguins = new GameObject[numberOfPenguins];
            penguins[0] = penguin;
            for (int i = 1; i < numberOfPenguins; i++)
            {
                penguins[i] = Instantiate(penguin, penguin.transform.position + 
                new Vector3((i % 3) * 2, 0, 2 * (int) (i / 3)), penguin.transform.rotation);
            }
            myAudioSource = GetComponent<AudioSource>();
            //myAudioSource.pitch = UnityEngine.Random.Range(1.4f, 1.6f);
        }
        void Resetlvl()
        {
            int sceneNumber = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneNumber);
        }
        // Update is called once per frame
        void Update()
        {
            if (numberOfPenguins - wetCount <= finishCrossCount && finishCrossCount >= 1)
            {
                successText.SetActive(true);
                continueButton.SetActive(true);
                if (!levelComplete)
                {
                    //win sound
                    AudioClip clip = winSound;
                    myAudioSource.PlayOneShot(clip);
                    levelComplete = true;
                }
            }
            else if (numberOfPenguins - wetCount <= 0)
            {
                failText.SetActive(true);
                Invoke("Resetlvl", 5);
                if (!levelComplete)
                {
                    //lose sound
                    AudioClip clip = loseSound;
                    myAudioSource.PlayOneShot(clip);
                    levelComplete = true;
                }
            }           
        }
    }
}
