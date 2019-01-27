using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public GameObject sucessText;
        public GameObject failText;

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
        }

        // Update is called once per frame
        void Update()
        {
            if (numberOfPenguins - wetCount <= finishCrossCount && finishCrossCount >= 1)
            {
                sucessText.SetActive(true);
            }
            else if (numberOfPenguins - wetCount <= 0)
            {
                failText.SetActive(true);
            }
            
            
        }
    }
}
