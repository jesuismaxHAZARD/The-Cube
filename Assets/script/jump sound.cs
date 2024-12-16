using UnityEngine;

public class JumpSound : MonoBehaviour
{
    public AudioSource jumpSource; // Référence au AudioSource
    public AudioClip jumpSound; // Clip sonore pour le saut

    private FPSCameraMovement playerScript;

    void Start()
    {
        // Assurez-vous que le composant AudioSource est bien assigné
        if (jumpSource == null)
        {
            jumpSource = GetComponent<AudioSource>();
        }

        // Trouver le script FPSCameraMovement sur le joueur
        playerScript = GetComponent<FPSCameraMovement>();
    }

    void Update()
    {
        // Si le joueur appuie sur espace et qu'il n'est pas déjà en train de sauter, jouer le son
        if (playerScript != null && Input.GetKeyDown(KeyCode.Space) && !playerScript.IsJumping())
        {
            PlayJumpSound();
        }
    }

    void PlayJumpSound()
    {
        if (jumpSource != null && jumpSound != null)
        {
            jumpSource.PlayOneShot(jumpSound); // Joue le son du saut
        }
    }
}