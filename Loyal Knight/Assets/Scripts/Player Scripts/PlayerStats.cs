using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    // Basic Stats
    public float health;
    public float stamina;
    public float focus; // Ability Points for the ability gauge

    // Damage Related
    public float physicalDamage;
    public float magicDamage;
    public float damageMultiplier;

    // Defence
    public float armour;

    private void Awake()
    {
        // Singleton Logic
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Keep across scenes
    }
}
