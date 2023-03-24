using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; // Cible à suivre
    public float speed = 5f; // Vitesse de déplacement

    private bool isFollowing = false; // Variable pour suivre ou non la cible
    public Sprite newSprite; // Nouveau sprite pour l'entité

    public float teleportDistance = 10f; // Distance maximale à laquelle l'entité peut être de la cible pour être téléportée
    public Sprite correctSkin; // Le bon skin que l'entité doit porter pour être téléportée
    public Transform teleportTarget; // La cible à laquelle l'entité sera téléportée

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = true;
            // Change le sprite de l'entité si le joueur la touche
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }

    private void Update()
    {
        if (isFollowing && target != null) // Vérifie si la cible est définie et que l'entité doit la suivre
        {
            // Vérifie si l'entité est suffisamment proche de la cible pour être téléportée
            if (Vector2.Distance(transform.position, target.position) > teleportDistance)
            {
                // Vérifie si l'entité porte le bon skin
                if (GetComponent<SpriteRenderer>().sprite == correctSkin)
                {
                    // Téléporte l'entité à la cible
                    transform.position = teleportTarget.position;
                }
            }
            else
            {
                // Calcul la direction de la cible
                Vector2 direction = target.position - transform.position;
                direction.Normalize();

                // Déplace l'entité vers la cible à la vitesse spécifiée
                transform.position += (Vector3)direction * speed * Time.deltaTime;
            }
        }
    }
}
