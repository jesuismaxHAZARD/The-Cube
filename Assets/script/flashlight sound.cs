using UnityEngine;

public class ToggleSoundWithF : MonoBehaviour
{
    public AudioSource sound; // Référence à l'AudioSource pour le son
    public AudioClip walkSound; // Le son du pas que vous souhaitez utiliser
    public KeyCode toggleKey = KeyCode.F; // Touche pour activer/désactiver le son
    private bool isSoundPlaying = false; // Indique si le son est actuellement joué

    void Start()
    {
        // S'assurer que l'AudioSource a bien le clip assigné au départ
        if (walkSound != null)
        {
            sound.clip = walkSound;
        }
    }

    void Update()
    {
        // Si la touche F est pressée, activer ou désactiver le son
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleSound();
        }
    }

    void ToggleSound()
    {
        if (isSoundPlaying)
        {
            sound.Stop(); // Si le son joue, arrêtez-le
        }
        else
        {
            if (walkSound != null)
            {
                sound.Play(); // Si le son ne joue pas, démarrez-le
            }
        }
        isSoundPlaying = !isSoundPlaying; // Inverse l'état du son (joué ou non)
    }
}