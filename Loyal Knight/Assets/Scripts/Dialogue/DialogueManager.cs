using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Value for the radius in which can be interacted with the NPC's dialogue
    public float interactionRadius = 3f;

    // Creates an array named npcs that keeps track of every object with the NPCDialogue component
    private NPCDialogue[] _npcs;

    // Stores the NPC that is the closest to the player. Can only be a object with the NPCDialogue component
    private NPCDialogue _closestNPC;

    void Start()
    {
        // Find only gameobjects with the NPCDialogue component and adds them to the array
        _npcs = FindObjectsByType<NPCDialogue>(FindObjectsSortMode.None);
    }

    void Update()
    {
        // Determine the closest NPC to the player
        // and show its next dialogue line if E is pressed
        // (currently using Debug.Log for testing)
        FindClosestNPC();

        if (_closestNPC != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(_closestNPC.GetNextDialogueLine());
        }
    }

    /// <summary>
    /// Calculates the distance between a npc and the player and determines the closest one
    /// </summary>
    private void FindClosestNPC()
    {
        // Makes sure the value is very high in the beginning
        float closestDistance = Mathf.Infinity;
        _closestNPC = null;

        
        foreach (NPCDialogue npc in _npcs)
        {
            // Calculate the distance from this NPC to the player
            float distance = Vector3.Distance(npc.transform.position, transform.position);

            // If this NPC is closer than any previously checked NPC
            // And within the interaction radius, mark it as the closest
            if (distance < closestDistance && distance <= interactionRadius)
            {
                closestDistance = distance;
                _closestNPC = npc;
            }
        }

        // If it is not empty, say the name of the closest NPC
        if (_closestNPC != null)
        {
            Debug.Log("Nearest NPC target is " + _closestNPC.name);
        }
    }

    /// <summary>
    /// Draw the Gizmos of the value of the interactionRadius
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
