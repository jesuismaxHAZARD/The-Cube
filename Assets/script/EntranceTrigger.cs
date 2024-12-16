using UnityEngine;
using UnityEngine.SceneManagement;  // Pour changer de scène

public class EntranceTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet entrant dans le trigger est le joueur et s'il a le cube
        if (other.CompareTag("Player") && InteractionPrompt.hasCube)
        {
            SceneManager.LoadScene("Victoire");  // Charge la scène Victoire
        }
    }
}