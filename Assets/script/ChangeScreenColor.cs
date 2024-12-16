using UnityEngine;
using UnityEngine.UI;  // Nécessaire pour manipuler l'UI Image
using UnityEngine.SceneManagement;  // Pour charger une nouvelle scène
using System.Collections;  // Ajout pour IEnumerator

public class ChangeScreenColor : MonoBehaviour
{
    public Image screenOverlay;  // Référence à l'UI Image que vous avez créée
    private int hitCount = 0;    // Compteur des coups reçus
    private bool isInDefeat = false;  // Vérifie si on doit aller à la scène de défaite

    void Start()
    {
        // Assurez-vous que l'overlay est transparent au début
        if (screenOverlay != null)
        {
            screenOverlay.color = new Color(1f, 0f, 0f, 0f); // Transparent (rouge avec alpha = 0)
        }
    }

    // Cette méthode sera appelée lorsque le monstre touche le joueur
    public void OnMonsterHit()
    {
        hitCount++;

        if (hitCount == 1)
        {
            StartCoroutine(ChangeColorIntensity(0.2f)); // Rouge à 20% d'intensité
        }
        else if (hitCount == 2)
        {
            StartCoroutine(ChangeColorIntensity(0.5f)); // Rouge à 50% d'intensité
        }
        else if (hitCount == 3)
        {
            StartCoroutine(ChangeColorIntensity(1f)); // Rouge à pleine intensité
            if (!isInDefeat)
            {
                isInDefeat = true;
                Invoke(nameof(LoadDefeatScene), 3f);  // Attendre 3 secondes avant de charger la scène de défaite
            }
        }
    }

    // Change l'intensité de la couleur rouge
    public IEnumerator ChangeColorIntensity(float targetAlpha)
    {
        float elapsedTime = 0f;
        Color currentColor = screenOverlay.color;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(currentColor.a, targetAlpha, elapsedTime);
            screenOverlay.color = new Color(1f, 0f, 0f, alpha); // Appliquer la couleur rouge avec l'intensité (alpha)
            yield return null;
        }
    }

    // Charge la scène de défaite après 3 secondes
    private void LoadDefeatScene()
    {
        SceneManager.LoadScene("Défaite");  // Charge la scène "Défaite"
    }
}