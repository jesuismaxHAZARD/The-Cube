using UnityEngine;

public class FootstepsSound : MonoBehaviour
{
    public AudioSource walkSource;
    public AudioClip walkSound;
    public float stepThreshold = 0.1f;
    public float stepInterval = 0.5f;

    private bool isWalking = false;
    private float stepTimer = 0f;

    void Start()
    {
        walkSource.loop = false;
    }

    void Update()
    {
        bool isMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > stepThreshold || Mathf.Abs(Input.GetAxis("Vertical")) > stepThreshold;

        if (isMoving && !isWalking)
        {
            isWalking = true;
            stepTimer = stepInterval;
            PlayWalkingSound();
        }
        else if (!isMoving && isWalking)
        {
            isWalking = false;
            StopWalkingSound();
        }

        if (isWalking)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayWalkingSound();
                stepTimer = stepInterval;
            }
        }
    }

    void PlayWalkingSound()
    {
        if (!walkSource.isPlaying)
            walkSource.PlayOneShot(walkSound);
    }

    void StopWalkingSound()
    {
        walkSource.Stop();
    }
}