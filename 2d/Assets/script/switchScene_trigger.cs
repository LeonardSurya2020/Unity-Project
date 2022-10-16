using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScene_trigger : MonoBehaviour
{
    switch_scene switchscene;

    [SerializeField]
    private string sceneName;
    private bool isPlayer = false;

    private void Start()
    {
        switchscene = FindObjectOfType<switch_scene>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

         if (collision.tag == "Player")
         {
            isPlayer = true;
               // switchscene.switchScene(sceneName);
         }
    }

    private void Update()
    {
        if(isPlayer == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                switchscene.switchScene(sceneName);
            }
        }
    }
}
