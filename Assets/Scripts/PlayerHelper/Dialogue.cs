using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/*The Dialogue script is responsible for the implementation of the Helper's Dialogue panels through
 out play. */
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float TextSpeed;
    public string wordsSaid; 
    private int index; 


    /*The startDialogue method is set to start upon the user entering the scene.*/
    void Start()
    {

        textComponent.text = string.Empty;
        startDialogue();
    }

    
    /*When pressing the Z key, the user may call the nextLine method, or if there isn't a next
     line then they can stop all coroutines. */
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Z)) {

            if (textComponent.text == lines[index])
            {
                nextLine();
            }

            else
            {

                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    /*This sets the line index of the current dialogue to 0, ready to begin.*/
    private void startDialogue() { 
        index = 0;
        StartCoroutine(TypeLine());
    
    }

    /*The next Line method checks to see if the current line index is less than the
     length of lines -1. If it is index iterates and text is typed into that line
    via the Coroutine TypeLine.*/
    private void nextLine() {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            gameObject.SetActive(false);
        }
    }

    /*This IEnumerator uses a character array to produce text one character at a time to a line,
     and waits for the seconds assigned to the TextSpeed float variable.*/
    private IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray()) {

            textComponent.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    
    }
}
/*<!--Number Planet - Dialogue
@Author: Julian Laffin -->*/
