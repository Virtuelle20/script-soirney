using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Si l'entité entre en collision avec le joueur, on la détruit
            Destroy(gameObject);
        }
    }
}
