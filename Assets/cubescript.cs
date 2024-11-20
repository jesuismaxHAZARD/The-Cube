using UnityEngine;

public class FloatingRotatingCube : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Vitesse de mouvement vertical
    public float rotationSpeed = 50f; // Vitesse de rotation
    public float heightAmplitude = 0.5f; // Amplitude du mouvement vertical (distance haut/bas)

    private Vector3 startPosition; // Position initiale du cube

    void Start()
    {
        // Stocke la position initiale
        startPosition = transform.position;

        // Assurer que le cube est gris
        Renderer cubeRenderer = GetComponent<Renderer>();
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = Color.gray;
        }
    }

    void Update()
    {
        // Faire osciller le cube entre une hauteur minimale et maximale
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * heightAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        // Faire tourner le cube autour de l'axe Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}