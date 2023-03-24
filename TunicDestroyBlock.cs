using UnityEngine;

public class TunicDestroyBlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            // Si l'entité entre en collision avec le joueur, on la détruit
            Destroy(gameObject);
        }
    }
}
