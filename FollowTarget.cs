using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; // Cible � suivre
    public float speed = 5f; // Vitesse de d�placement

    private bool isFollowing = false; // Variable pour suivre ou non la cible
    public Sprite newSprite; // Nouveau sprite pour l'entit�

    public float teleportDistance = 10f; // Distance maximale � laquelle l'entit� peut �tre de la cible pour �tre t�l�port�e
    public Sprite correctSkin; // Le bon skin que l'entit� doit porter pour �tre t�l�port�e
    public Transform teleportTarget; // La cible � laquelle l'entit� sera t�l�port�e

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = true;
            // Change le sprite de l'entit� si le joueur la touche
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }

    private void Update()
    {
        if (isFollowing && target != null) // V�rifie si la cible est d�finie et que l'entit� doit la suivre
        {
            // V�rifie si l'entit� est suffisamment proche de la cible pour �tre t�l�port�e
            if (Vector2.Distance(transform.position, target.position) > teleportDistance)
            {
                // V�rifie si l'entit� porte le bon skin
                if (GetComponent<SpriteRenderer>().sprite == correctSkin)
                {
                    // T�l�porte l'entit� � la cible
                    transform.position = teleportTarget.position;
                }
            }
            else
            {
                // Calcul la direction de la cible
                Vector2 direction = target.position - transform.position;
                direction.Normalize();

                // D�place l'entit� vers la cible � la vitesse sp�cifi�e
                transform.position += (Vector3)direction * speed * Time.deltaTime;
            }
        }
    }
}
