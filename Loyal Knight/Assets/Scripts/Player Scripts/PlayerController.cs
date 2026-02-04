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
        float verticalTranslation = Input.GetAxis("Vertical") * currentMovementSpeed;
        float horizontalTranslation = Input.GetAxis("Horizontal") * currentMovementSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make the player move
        transform.Translate(horizontalTranslation * Time.deltaTime, 0, verticalTranslation * Time.deltaTime);

        // Make the player rotate the character
        // TODO: Zoom in and out with the camera.

        // TODO: Control the camera over the scen, with a rest to its original state and a limit to how far the camera can go

        // OLD ---- transform.Rotate(0, rotation * Time.deltaTime, 0);

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
            currentMovementSpeed = standardMovementSpeed * sprintValue;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // Movementspeed is set to the value of standardMovementSpeed
            currentMovementSpeed = standardMovementSpeed;
        }
    }
}