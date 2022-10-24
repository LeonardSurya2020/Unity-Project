using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class story_dialogue : MonoBehaviour
{
    public GameObject dialoguepanel;
    public GameObject dialoguepanel_2;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    public int index;
    int a = 0;

    public float textSpeed;
    private bool close;
    private bool trigg;

    private void Start()
    {
        trigg = true;
        close = true;
    }
    void Update()
    {
        if (trigg == true)
        {
            if (close == true )
            {

                close = false;
                StartCoroutine(ShowText());


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
            dialoguepanel_2.SetActive(true);
            ZeroText();
        }

    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguepanel.SetActive(false);
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

    
}
