using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Value for the standard movement speed
    public float standardMovementSpeed = 10.0f;
    // Value of the multiplier for the sprinting mechanic
    public float sprintValue = 1.8f;
    // Value for the current movement speed
    public float currentMovementSpeed;
    // Value for the rotation speed
    public float rotationSpeed = 100.0f;

    
    void Start()
    {
        // Set values, gameobject, etc at the start so it can't be forgotten about
        SetAtStart();
    }

    void Update()
    {
        // Ensures the player is able to move
        Movement();
    }

    /// <summary>
    /// Set values, gameobject, etc at the start so it can't be forgotten about
    /// </summary>
    public void SetAtStart()
    {
        currentMovementSpeed = standardMovementSpeed;
    }

    /// <summary>
    /// Handles the movement of the player
    /// </summary>
    private void Movement()
    {
        // Get the translation and rotation values and increment them with the movement or rotation speed
        float translation = Input.GetAxis("Vertical") * currentMovementSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make the player move
        transform.Translate(0, 0, translation * Time.deltaTime);

        // Make the player rotate the character
        transform.Rotate(0, rotation * Time.deltaTime, 0);

        // The player can sprint with LeftShift
        Sprinting();
    }

    /// <summary>
    /// Player sprints with while holding left shift and stops when the button is not pressed
    /// </summary>
    public void Sprinting()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Movementspeed is multiplied by the value of sprintValue
            currentMovementSpeed = currentMovementSpeed * sprintValue;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // Movementspeed is set to the value of standardMovementSpeed
            currentMovementSpeed = standardMovementSpeed;
        }
    }
}