using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_manager : MonoBehaviour
{
    public int level;
    int trig = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("level " + level.ToString());
    }
}
