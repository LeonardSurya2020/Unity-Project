using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    
    public GameObject dialogPanel;
    
    public Text dialogText;
    public string[] dialogue;
    public int index;
    int a = 0;

    public float textSpeed;
    private bool close;
   
    void Update()
    {
        
        if (close == true && Input.GetKeyDown(KeyCode.Space))
        {
            
            close = false;
            if (a <= 0)
            {
                if (dialogPanel.activeInHierarchy)
                {
                    ZeroText();
                }
                else
                {
                    dialogPanel.SetActive(true);
                    StartCoroutine(ShowText());
                }
            }
            
             
        }

        else if (close == false && Input.GetKeyDown(KeyCode.Space))
        {
            nextLine();
        }

    }

    public void nextLine()
    {
       if (index < dialogue.Length - 1)
       {
          index++;
          dialogText.text = "";
          StartCoroutine(ShowText());
       }
       else
       {
          ZeroText();
       }
        
    }

    public void ZeroText()
    {
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
        close = true;
    }

    IEnumerator ShowText()
    {
        
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                close = true;
                ZeroText();
            }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            close = false;
            ZeroText();
        }
    }
}