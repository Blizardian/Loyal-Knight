using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [Header("Set in the inspector")]
    public Camera mainCamera;
    public LayerMask enemyLayer; // Tracks the layer the enemies are on

    private GameObject hoverOverPossibleTarget;
    public GameObject target;
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyLayer))
        {
            // Mouse is over some enemy
            GameObject hitTarget = hit.collider.gameObject;

            if (hitTarget != hoverOverPossibleTarget)
            {
                hoverOverPossibleTarget = hitTarget;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                target = hoverOverPossibleTarget;
                Debug.Log("Clicked on " + hoverOverPossibleTarget.name);
                // TODO: Add logic for making the enemy the target
            }
        }
    }
}
