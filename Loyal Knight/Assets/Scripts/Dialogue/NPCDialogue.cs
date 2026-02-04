using UnityEngine;
using UnityEngine.Events;

public class NPCDialogue : MonoBehaviour
{
    // Array for the lines of dialogue
    [TextArea]
    public string[] dialogueLines;

    // UnityEvent for calling events between dialogue (Like opening a menu)
    public UnityEvent[] dialogueEvents;

    // Value that keeps track of the dialogue line numbers
    private int _dialogueNumber;

    /// <summary>
    /// Gets the next dialogue line, looks if there is an event that needs to be called, if so calls it.
    /// </summary>
    /// <returns></returns>
    public string GetNextDialogueLine()
    {
        // Get the dialogue line
        string line = dialogueLines[_dialogueNumber];

        // If there is a event, call it
        if (dialogueEvents != null && _dialogueNumber < dialogueEvents.Length && dialogueEvents[_dialogueNumber] != null)
        {
            dialogueEvents[_dialogueNumber].Invoke();
        }

        // Advance the dialogue number
        _dialogueNumber = (_dialogueNumber + 1) % dialogueLines.Length;

        return line;
    }
}