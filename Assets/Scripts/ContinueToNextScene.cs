using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueToNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Next()
    {
        int nextScene = 0;
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        nextScene = ++sceneNumber;
        SceneManager.LoadScene(nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
