using UnityEngine;

public class FPSCameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement avant/arrière
    public float turnSpeed = 150f; // Vitesse de rotation gauche/droite

    void Update()
    {
        // Déplacement sur l'axe X local de la caméra
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self); // Déplace à droite
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.Self); // Déplace à gauche
        }

        // Rotation gauche/droite sur l'axe Y de la caméra
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime); // Rotation gauche
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime); // Rotation droite
        }
    }
}

