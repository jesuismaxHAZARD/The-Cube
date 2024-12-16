using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Chargez la scène du jeu 3D
        SceneManager.LoadScene("Jeu_3D");
    }

    public void QuitGame()
    {
        // Quittez le jeu (fonctionne dans une build, pas dans l'éditeur)
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}