using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSCameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeedX = 2f;
    public float lookSpeedY = 2f;
    public float jumpForce = 5f;
    public float shakeIntensity = 0.05f;
    public float shakeFrequency = 1f;
    public Transform cameraTransform;

    private Rigidbody rb;
    private float rotationX = 0f;
    private Vector3 originalPosition;
    private float shakeTimer = 0f;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        if (cameraTransform == null)
        {
            cameraTransform = GetComponentInChildren<Camera>().transform;
        }

        originalPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        HandleRotation();
        HandleJump();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += transform.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection -= transform.forward;
        if (Input.GetKey(KeyCode.A)) moveDirection -= transform.right;
        if (Input.GetKey(KeyCode.D)) moveDirection += transform.right;

        moveDirection.y = 0;
        Vector3 newPosition = rb.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        if (moveDirection.magnitude > 0)
        {
            shakeTimer += Time.fixedDeltaTime * shakeFrequency;
            ShakeCamera();
        }
        else
        {
            cameraTransform.localPosition = originalPosition;
            shakeTimer = 0f;
        }
    }

    void HandleRotation()
    {
        // Rotation verticale (haut/bas) pour la caméra
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Rotation horizontale (gauche/droite) pour le personnage
        float rotationY = Input.GetAxis("Mouse X") * lookSpeedX;
        transform.Rotate(0f, rotationY, 0f); // Utilisation de Transform.Rotate pour éviter les conflits physiques
    }

    void HandleJump()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Invoke(nameof(ResetJump), 0.5f); // Attendre un moment avant de réactiver le saut
        }
    }

    void ResetJump()
    {
        isJumping = false;
    }

    public bool IsJumping()
    {
        return isJumping;
    }


    void ShakeCamera()
    {
        float shakeY = Mathf.Sin(shakeTimer) * shakeIntensity;
        cameraTransform.localPosition = new Vector3(originalPosition.x, originalPosition.y + shakeY, originalPosition.z);
    }
}