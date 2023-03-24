using UnityEngine;

public class ChangeSkinOnTrigger : MonoBehaviour
{
    public Sprite newSkin; // le nouveau skin à appliquer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // récupère le composant SpriteRenderer du joueur
            SpriteRenderer playerRenderer = collision.GetComponent<SpriteRenderer>();

            // vérifie que le composant existe
            if (playerRenderer != null)
            {
                // change le sprite du joueur pour le nouveau skin
                playerRenderer.sprite = newSkin;

            }
        }
    }
}

