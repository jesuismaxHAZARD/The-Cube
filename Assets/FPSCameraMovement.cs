using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSCameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement
    public float lookSpeedX = 2f; // Sensibilité de la rotation horizontale (gauche/droite) avec la souris
    public float lookSpeedY = 2f; // Sensibilité de la rotation verticale (haut/bas) avec la souris

    private Rigidbody rb; // Référence au Rigidbody
    private float rotationX = 0f; // Variable pour limiter la rotation verticale
    public Transform cameraTransform; // Référence à la caméra enfant

    void Start()
    {
        // Initialisation du Rigidbody
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Empêche la rotation automatique par la physique

        // Si aucune caméra n'est assignée, cherche automatiquement une caméra enfant
        if (cameraTransform == null)
        {
            cameraTransform = GetComponentInChildren<Camera>().transform;
        }
    }

    void Update()
    {
        HandleRotation(); // Gestion de la rotation avec la souris
    }

    void FixedUpdate()
    {
        HandleMovement(); // Gestion des mouvements avec les touches fléchées
    }

    void HandleMovement()
    {
        // Calcul du déplacement en fonction des touches fléchées
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) // Avancer
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow)) // Reculer
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // Aller à gauche
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Aller à droite
        {
            moveDirection += transform.right;
        }

        // Applique le mouvement au Rigidbody
        Vector3 newPosition = rb.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    void HandleRotation()
    {
        // Rotation verticale (haut/bas) de la caméra avec la souris
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f); // Limite de l'angle vertical
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Applique la rotation verticale

        // Rotation horizontale (gauche/droite) du personnage avec la souris
        float rotationY = Input.GetAxis("Mouse X") * lookSpeedX;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotationY, 0f)); // Applique la rotation horizontale
    }
}