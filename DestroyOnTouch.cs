using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Si l'entit� entre en collision avec le joueur, on la d�truit
            Destroy(gameObject);
        }
    }
}
