using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DialogueManger : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogeText;
    public navigation nextDialoge;


    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void startDialogue(Dialogue dialogue)
    {
        sentences = new Queue<string>();
        nextDialoge.enableBtn();
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        displayNextSentence();
    }

    public void displayNextSentence()
    {
        if (sentences.Count == 0)
        {
            endDialogue();
        }
        else if(sentences.Count == 1){
            nextDialoge.transform.gameObject.SetActive(false);
        }

        string sentence =  sentences.Dequeue();
        dialogeText.text = sentence;
    }

    public void endDialogue()
    {
        Debug.Log("end of");
    }

}
