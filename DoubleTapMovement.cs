using UnityEngine;

public class DoubleTapMovement : MonoBehaviour
{
    public float doubleTapTime = 0.5f; // Temps maximal entre deux clics pour détecter un double-clic
    public float distance = 5f; // Distance du waypoint à créer
    public float speed = 5f; // Vitesse de déplacement de l'entité
    public float doubleTapCooldown = 0.5f; // Temps de recharge entre chaque double-clic
    public Sprite requiredSkin; // Le sprite requis pour permettre le déplacement
    public float triggerDisableTime = 0.2f; // Temps avant que le BoxCollider2D ne soit plus un trigger

    private float lastClickTime; // Temps du dernier clic
    private Vector3 lastPosition; // Position du dernier clic
    private bool movingToWaypoint; // Si l'entité est en train de se déplacer vers le waypoint
    private Vector3 waypointPosition; // Position du waypoint actuel
    private GameObject currentWaypoint; // Le waypoint actuel
    private float timeSinceStartedMoving; // Temps depuis que l'entité s'est mise en mouvement vers un waypoint

    private BoxCollider2D boxCollider2D; // Référence au BoxCollider2D de l'entité

    void Start()
    {
        // Récupérer le BoxCollider2D de l'entité
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Vérifier si le sprite actuel correspond au sprite requis pour permettre le déplacement
        if (GetComponent<SpriteRenderer>().sprite == requiredSkin)
        {
            // Vérifier si la touche de direction droite ou gauche a été double-cliquée
            if (DoubleTap(KeyCode.RightArrow, doubleTapTime))
            {
                // Double-clic sur la flèche directionnelle droite détecté, créer un waypoint à droite de l'entité
                CreateWaypoint(transform.right);
            }
            else if (DoubleTap(KeyCode.LeftArrow, doubleTapTime))
            {
                // Double-clic sur la flèche directionnelle gauche détecté, créer un waypoint à gauche de l'entité
                CreateWaypoint(-transform.right);
            }
        }

        // Si l'entité est en train de se déplacer vers un waypoint, vérifier si le BoxCollider2D doit être désactivé
        if (movingToWaypoint && timeSinceStartedMoving >= triggerDisableTime && boxCollider2D.isTrigger)
        {
            boxCollider2D.isTrigger = false;
        }
    }

    private void FixedUpdate()
    {
        // Si l'entité est en train de se déplacer vers le waypoint, la faire avancer
        if (movingToWaypoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypointPosition, speed * Time.deltaTime);
            timeSinceStartedMoving += Time.deltaTime;
            if (Vector3.Distance(transform.position, waypointPosition) < 0.1f)
            {
                // Arrivé au waypoint, arrêter le mouvement et détruire le waypoint
                movingToWaypoint = false;
                Destroy(currentWaypoint);
                timeSinceStartedMoving = 0f;
                boxCollider2D.isTrigger = true; // Réactiver le BoxCollider2D en tant que trigger
            }
        }

        else
        {
            // Gérer l'input de déplacement de l'entité ici
        }
    }

    private bool DoubleTap(KeyCode key, float time)
    {
        if (Input.GetKeyDown(key))
        {
            if (Time.time -lastClickTime < time && Vector3.Distance(transform.position, lastPosition) < 1f)
            {
                lastClickTime = Time.time + doubleTapCooldown; // Définir le temps de recharge
                lastPosition = Vector3.zero;
                return true;
            }
            lastClickTime = Time.time;
            lastPosition = transform.position;
        }
        return false;
    }

    private void CreateWaypoint(Vector3 direction)
    {
        // Créer un waypoint à une distance dans la direction spécifiée
        waypointPosition = transform.position + direction * distance;
        currentWaypoint = new GameObject("Waypoint");
        currentWaypoint.transform.position = waypointPosition;

        // Déplacer l'entité vers le waypoint
        movingToWaypoint = true;
    }
}
