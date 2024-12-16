using UnityEngine;
using UnityEngine.SceneManagement;  // Pour charger une nouvelle scène
using UnityEngine.UI;  // Pour gérer les éléments UI (comme les boutons)

public class DefeatMenuController : MonoBehaviour
{
    public Button menuButton;  // Référence au bouton "Retour au Menu"

    void Start()
    {
        // Ajouter un écouteur pour l'événement "click" du bouton
        menuButton.onClick.AddListener(LoadMenuScene);
    }

    // Méthode pour charger la scène du menu
    void LoadMenuScene()
    {
        // Charger la scène "Menu_2D" (assure-toi que le nom de ta scène est correct)
        SceneManager.LoadScene("Menu_2D");
    }
}