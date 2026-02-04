using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header ("Set in the inspector")]
    public Slider healthBar;
    public Slider focusBar;

    void Update()
    {
        UpdateSliders();
    }

    /// <summary>
    /// Updates the sliders to the current ammount of the value the player has of that variable
    /// </summary>
    private void UpdateSliders()
    {
        healthBar.value = PlayerStats.Instance.health;
        focusBar.value = PlayerStats.Instance.focus;
    }
}
