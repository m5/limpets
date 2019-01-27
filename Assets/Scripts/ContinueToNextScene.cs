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
        nextScene = (sceneNumber + 1);
        if(nextScene >= SceneManager.sceneCount)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }

    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
