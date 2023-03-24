using UnityEngine;

public class ChangeSkinOnTrigger : MonoBehaviour
{
    public Sprite newSkin; // le nouveau skin � appliquer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // r�cup�re le composant SpriteRenderer du joueur
            SpriteRenderer playerRenderer = collision.GetComponent<SpriteRenderer>();

            // v�rifie que le composant existe
            if (playerRenderer != null)
            {
                // change le sprite du joueur pour le nouveau skin
                playerRenderer.sprite = newSkin;

            }
        }
    }
}

