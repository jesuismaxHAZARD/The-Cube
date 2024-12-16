using UnityEngine;
using UnityEngine.SceneManagement;  // Pour changer de scène

public class InteractionPrompt : MonoBehaviour
{
    public GameObject promptUI;
    public Transform player;
    public float interactionRange = 3f;
    public KeyCode interactKey = KeyCode.E;
    public GameObject monster;
    public static bool hasCube = false;  // Indicateur pour savoir si le joueur a pris le cube

    void Start()
    {
        if (player == null)
        {
            player = Camera.main.transform;
        }

        if (monster != null)
        {
            monster.SetActive(false);  // Le monstre est désactivé au début
        }
    }

    void Update()
    {
        if (player == null || promptUI == null)
        {
            Debug.LogError("Player or PromptUI is not assigned!");
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= interactionRange)
        {
            promptUI.SetActive(true);
            promptUI.transform.Rotate(0f, 180f, 0f);

            if (Input.GetKeyDown(interactKey))
            {
                Interact();
            }
        }
        else
        {
            promptUI.SetActive(false);
        }
    }

    void Interact()
    {
        promptUI.SetActive(false);
        gameObject.SetActive(false);

        if (monster != null)
        {
            monster.SetActive(true);  // Active le monstre une fois l'interaction terminée
        }

        hasCube = true;  // Le joueur a maintenant le cube
    }
}