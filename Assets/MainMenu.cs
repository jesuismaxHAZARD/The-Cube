using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Chargez la scène du jeu (remplacez "GameScene" par le nom de votre scène 3D)
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        // Quittez le jeu (fonctionne dans une build, pas dans l'éditeur)
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}