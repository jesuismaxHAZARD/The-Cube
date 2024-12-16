using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;  // Nécessaire pour manipuler l'UI Image
using UnityEngine.SceneManagement;  // Pour charger une nouvelle scène

public class MonsterAIController : MonoBehaviour
{
    public Transform player; 
    public float chaseRange = 10f; 
    public float attackRange = 2f;  // Distance à laquelle il s'arrête avant d'attaquer
    public float moveSpeed = 3f; 
    private Animator animator; 
    private NavMeshAgent agent; 
    private bool isAttacking = false; 
    private bool isIdle = false;  // Pour vérifier si le monstre est en idle
    private ChangeScreenColor screenColorScript;  // Référence au script de changement de couleur
    private int hitCount = 0;  // Compteur des coups reçus
    private bool isInDefeat = false;  // Vérifie si le joueur a reçu 3 coups

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
        animator = GetComponent<Animator>(); 
        agent.speed = moveSpeed; 
        agent.stoppingDistance = attackRange;  // Arrêter à une distance avant d'attaquer
        screenColorScript = GetComponent<ChangeScreenColor>();  // Assurez-vous que le script ChangeScreenColor est attaché
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); 

        if (!isAttacking)
        {
            if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange)
            {
                if (isIdle) 
                {
                    animator.SetBool("isWalking", true);  // Commence à marcher
                    isIdle = false;
                }
                agent.SetDestination(player.position);
            }
            else if (distanceToPlayer <= attackRange)
            {
                agent.ResetPath();  // Arrête de se déplacer
                animator.SetBool("isWalking", false);  // Arrêt de l'animation de marche
                AttackPlayer();  // Lance l'attaque
            }
            else
            {
                if (!isIdle) 
                {
                    animator.SetBool("isWalking", false);  // Animation de marche désactivée
                    animator.Play("Creep|Idle1_Action");  // Jouer animation Idle (Creep|Idle1_Action)
                    isIdle = true;  // Marquer le monstre comme étant en idle
                }
                agent.ResetPath();  // Arrêt de la navigation si trop éloigné
            }
        }
    }

    void AttackPlayer()
    {
        if (!isAttacking) 
        {
            isAttacking = true;
            animator.SetBool("isWalking", false);  // Arrête la marche avant d'attaquer
            int randomAttack = Random.Range(0, 2); 
            if (randomAttack == 0)
            {
                animator.SetTrigger("Bite");  // Déclenche l'animation de morsure
            }
            else
            {
                animator.SetTrigger("Punch");  // Déclenche l'animation de punch
            }

            // Appel de la méthode OnMonsterHit dans le script ChangeScreenColor
            OnMonsterHit();

            Invoke(nameof(ResetAttack), 2f);  // Attendre 2 secondes avant de réinitialiser l'attaque
        }
    }

    void ResetAttack()
    {
        isAttacking = false;
        isIdle = false; // Le monstre peut se remettre à marcher
    }

    // Méthode pour gérer l'augmentation de l'intensité du rouge et le comptage des coups
    public void OnMonsterHit()
    {
        hitCount++;

        if (hitCount == 1)
        {
            StartCoroutine(screenColorScript.ChangeColorIntensity(0.2f)); // Rouge à 20% d'intensité
        }
        else if (hitCount == 2)
        {
            StartCoroutine(screenColorScript.ChangeColorIntensity(0.5f)); // Rouge à 50% d'intensité
        }
        else if (hitCount == 3)
        {
            StartCoroutine(screenColorScript.ChangeColorIntensity(1f)); // Rouge à pleine intensité
            if (!isInDefeat)
            {
                isInDefeat = true;
                Invoke(nameof(LoadDefeatScene), 3f);  // Attendre 3 secondes avant de charger la scène de défaite
            }
        }
    }

    // Charge la scène de défaite après 3 secondes
    private void LoadDefeatScene()
    {
        SceneManager.LoadScene("Défaite");  // Charge la scène "Défaite"
    }
}