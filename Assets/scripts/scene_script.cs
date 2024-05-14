using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scene_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void NextScene()
    {
        SceneManager.LoadScene(1);

    }
    public void Quitgame()
    {
        Application.Quit();
    }
}
