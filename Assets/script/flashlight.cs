using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight; // Référence à la lumière de la lampe
    public KeyCode toggleKey = KeyCode.F; // Touche pour allumer/éteindre la lampe

    void Start()
    {
        // Si aucune lumière n'est assignée, chercher une lumière enfant
        if (flashlight == null)
        {
            flashlight = GetComponentInChildren<Light>();
        }
    }

    void Update()
    {
        HandleFlashlightToggle();
    }

    void HandleFlashlightToggle()
    {
        // Active ou désactive la lumière lorsqu'on appuie sur la touche toggleKey
        if (Input.GetKeyDown(toggleKey))
        {
            if (flashlight != null)
            {
                flashlight.enabled = !flashlight.enabled;
            }
        }
    }
}