using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogueText;
    public Text dialogText;
    public string[] dialogue;
    public int index;
    int a = 0;

    public float textSpeed;
    private bool close;
    private bool trigg;

    private void Start()
    {
        
    }
    void Update()
    {
        if(trigg == true)
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
        

    }

    public void nextLine()
    {
       if (index < dialogue.Length - 1)
       {
          index++;
          dialogueText.text = "";
          StartCoroutine(ShowText());
       }
       else
       {
          ZeroText();
       }
        
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
        close = true;
    }

    IEnumerator ShowText()
    {
        
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                trigg = true;
                close = true;
                ZeroText();
            }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            close = false;
            trigg = false;
            ZeroText();
        }
    }
}
