using UnityEngine;

public class CameraTravelling : MonoBehaviour
{
    public Vector3 endPosition; // Position finale de la caméra
    public float duration = 5f; // Durée du travelling en secondes
    private Vector3 startPosition;
    private float elapsedTime = 0f;

    void Start()
    {
        // Enregistrer la position de départ
        startPosition = transform.position;
    }

    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Interpolation entre la position de départ et la position finale
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
        }
    }
}