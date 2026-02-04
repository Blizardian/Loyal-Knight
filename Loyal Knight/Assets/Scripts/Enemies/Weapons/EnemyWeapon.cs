using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [Header("Set in the inspector!")]
    public Enemy1Behaviour enemy; // Referency to the first enemy's script

    public bool hasHit; // Checks if the player has been hit or not

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasHit)
        {
            hasHit = true; // Prevents multiple hits in one swing
            Debug.Log("Player is hit by " + gameObject.name);
            PlayerStats.Instance.health -= enemy.damage * enemy.damageMultiplier;
        }
    }
}
