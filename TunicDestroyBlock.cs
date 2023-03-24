using UnityEngine;

public class TunicDestroyBlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            // Si l'entit� entre en collision avec le joueur, on la d�truit
            Destroy(gameObject);
        }
    }
}
