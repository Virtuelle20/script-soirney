using UnityEngine;

public class DoubleTapMovement : MonoBehaviour
{
    public float doubleTapTime = 0.5f; // Temps maximal entre deux clics pour d�tecter un double-clic
    public float distance = 5f; // Distance du waypoint � cr�er
    public float speed = 5f; // Vitesse de d�placement de l'entit�
    public float doubleTapCooldown = 0.5f; // Temps de recharge entre chaque double-clic
    public Sprite requiredSkin; // Le sprite requis pour permettre le d�placement
    public float triggerDisableTime = 0.2f; // Temps avant que le BoxCollider2D ne soit plus un trigger

    private float lastClickTime; // Temps du dernier clic
    private Vector3 lastPosition; // Position du dernier clic
    private bool movingToWaypoint; // Si l'entit� est en train de se d�placer vers le waypoint
    private Vector3 waypointPosition; // Position du waypoint actuel
    private GameObject currentWaypoint; // Le waypoint actuel
    private float timeSinceStartedMoving; // Temps depuis que l'entit� s'est mise en mouvement vers un waypoint

    private BoxCollider2D boxCollider2D; // R�f�rence au BoxCollider2D de l'entit�

    void Start()
    {
        // R�cup�rer le BoxCollider2D de l'entit�
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // V�rifier si le sprite actuel correspond au sprite requis pour permettre le d�placement
        if (GetComponent<SpriteRenderer>().sprite == requiredSkin)
        {
            // V�rifier si la touche de direction droite ou gauche a �t� double-cliqu�e
            if (DoubleTap(KeyCode.RightArrow, doubleTapTime))
            {
                // Double-clic sur la fl�che directionnelle droite d�tect�, cr�er un waypoint � droite de l'entit�
                CreateWaypoint(transform.right);
            }
            else if (DoubleTap(KeyCode.LeftArrow, doubleTapTime))
            {
                // Double-clic sur la fl�che directionnelle gauche d�tect�, cr�er un waypoint � gauche de l'entit�
                CreateWaypoint(-transform.right);
            }
        }

        // Si l'entit� est en train de se d�placer vers un waypoint, v�rifier si le BoxCollider2D doit �tre d�sactiv�
        if (movingToWaypoint && timeSinceStartedMoving >= triggerDisableTime && boxCollider2D.isTrigger)
        {
            boxCollider2D.isTrigger = false;
        }
    }

    private void FixedUpdate()
    {
        // Si l'entit� est en train de se d�placer vers le waypoint, la faire avancer
        if (movingToWaypoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypointPosition, speed * Time.deltaTime);
            timeSinceStartedMoving += Time.deltaTime;
            if (Vector3.Distance(transform.position, waypointPosition) < 0.1f)
            {
                // Arriv� au waypoint, arr�ter le mouvement et d�truire le waypoint
                movingToWaypoint = false;
                Destroy(currentWaypoint);
                timeSinceStartedMoving = 0f;
                boxCollider2D.isTrigger = true; // R�activer le BoxCollider2D en tant que trigger
            }
        }

        else
        {
            // G�rer l'input de d�placement de l'entit� ici
        }
    }

    private bool DoubleTap(KeyCode key, float time)
    {
        if (Input.GetKeyDown(key))
        {
            if (Time.time -lastClickTime < time && Vector3.Distance(transform.position, lastPosition) < 1f)
            {
                lastClickTime = Time.time + doubleTapCooldown; // D�finir le temps de recharge
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
        // Cr�er un waypoint � une distance dans la direction sp�cifi�e
        waypointPosition = transform.position + direction * distance;
        currentWaypoint = new GameObject("Waypoint");
        currentWaypoint.transform.position = waypointPosition;

        // D�placer l'entit� vers le waypoint
        movingToWaypoint = true;
    }
}
