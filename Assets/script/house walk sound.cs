using UnityEngine;

public class WalkSoundInHouse : MonoBehaviour
{
    public AudioSource walkSound; // L'AudioSource pour le bruit de pas normal
    public AudioSource walkWoodSound; // L'AudioSource pour le bruit de pas bois
    public Transform player; // Le joueur
    private bool isInHouse = false; // Détermine si le joueur est dans la maison

    private void Update()
    {
        // Si le joueur est dans la maison et se déplace
        if (isInHouse)
        {
            if (!walkWoodSound.isPlaying && player.GetComponent<Rigidbody>().linearVelocity.magnitude > 0.1f)
            {
                walkWoodSound.Play(); // Joue le bruit de pas bois si le joueur bouge
            }
            else if (walkWoodSound.isPlaying && player.GetComponent<Rigidbody>().linearVelocity.magnitude < 0.1f)
            {
                walkWoodSound.Stop(); // Arrête le bruit de pas bois si le joueur ne bouge pas
            }
        }
        else
        {
            // Si le joueur est hors de la maison, arrête le bruit de pas bois et active le bruit de pas normal
            if (walkWoodSound.isPlaying)
            {
                walkWoodSound.Stop();
            }

            if (!walkSound.isPlaying && player.GetComponent<Rigidbody>().linearVelocity.magnitude > 0.1f)
            {
                walkSound.Play(); // Joue le bruit de pas normal si le joueur bouge
            }
        }
    }

    // Détection d'entrée dans la zone de la maison
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assurez-vous que le joueur entre dans la zone avec ce tag
        {
            isInHouse = true;
            if (walkSound.isPlaying)
            {
                walkSound.Stop(); // Arrête le bruit de pas normal
            }
        }
    }

    // Détection de sortie de la zone de la maison
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInHouse = false;
        }
    }
}