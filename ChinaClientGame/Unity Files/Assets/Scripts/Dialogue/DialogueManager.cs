using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text titleText;
    public Text dialogueText;

    public Animator animator; // Animations for the dialogue box

    [SerializeField]
    private Queue<string> sentences; // A queue collection (Another form of string array). Works in FIFO (First In First Out)

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); // Creates a queue of sentences 
    }

    public void StartDialogue(Dialogue dialogue)
	{
        animator.SetBool("IsOpen", true); // Dialogue Box pops up

        titleText.text = dialogue.title; // Unity's text sets as our title from Dialogue Trigger

        sentences.Clear(); // Clears the sentences

		foreach (string sentence in dialogue.sentences)
		{
            sentences.Enqueue(sentence); // Starts from the start of the dialogue
		}

        DisplayNextSentence();
	}

    public void DisplayNextSentence()
	{
        if(sentences.Count == 0) // If no new dialogue is in queue
		{
            EndDialogue();
            return;
		}

        string sentence = sentences.Dequeue(); // Selects the next dialogue
        StopAllCoroutines(); // Stops all sentences if player skips them
        StartCoroutine(TypeSentence(sentence)); // Starts the coroutine of the sentences one by one
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) // Prints out the sentences letter by letter
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
	{
        animator.SetBool("IsOpen", false); // Exits pop up

    }
}
