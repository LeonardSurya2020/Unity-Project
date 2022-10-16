using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switch_scene : MonoBehaviour
{
    public static string prevScene;
    public static string currentScene;

    
    public virtual void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void switchScene(string scene_name)
    {
        prevScene = currentScene;
        SceneManager.LoadScene(scene_name);
    }
}
