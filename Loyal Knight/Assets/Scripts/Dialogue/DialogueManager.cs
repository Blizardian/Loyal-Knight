using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Value for the radius in which can be interacted with the NPC's dialogue
    public float interactionRadius = 3f;

    // Creates an array named npcs that keeps track of every object with the NPCDialogue component
    private NPCDialogue[] npcs;

    // Stores the NPC that is the closest to the player. Can only be a object with the NPCDialogue component
    private NPCDialogue closestNPC;

    void Start()
    {
        // Find only gameobjects with the NPCDialogue component and adds them to the array
        npcs = FindObjectsByType<NPCDialogue>(FindObjectsSortMode.None);
    }

    void Update()
    {
        // Determine the closest NPC to the player
        // and show its next dialogue line if E is pressed
        // (currently using Debug.Log for testing)
        FindClosestNPC();

        if (closestNPC != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(closestNPC.GetNextDialogueLine());
        }
    }

    /// <summary>
    /// Calculates the distance between a npc and the player and determines the closest one
    /// </summary>
    private void FindClosestNPC()
    {
        // Makes sure the value is very high in the beginning
        float closestDistance = Mathf.Infinity;
        closestNPC = null;

        
        foreach (NPCDialogue npc in npcs)
        {
            // Calculate the distance from this NPC to the player
            float distance = Vector3.Distance(npc.transform.position, transform.position);

            // If this NPC is closer than any previously checked NPC
            // And within the interaction radius, mark it as the closest
            if (distance < closestDistance && distance <= interactionRadius)
            {
                closestDistance = distance;
                closestNPC = npc;
            }
        }

        // If it is not empty, say the name of the closest NPC
        if (closestNPC != null)
        {
            Debug.Log("Nearest NPC target is " + closestNPC.name);
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
