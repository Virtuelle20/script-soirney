using UnityEngine;

public class ChangeSkinfakeOnTrigger : MonoBehaviour
{
    public Sprite fakeSkin; // le skin de faux à appliquer

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("skin_change"))
        {
            // récupère le composant SpriteRenderer du joueur
            SpriteRenderer playerRenderer = collision.GetComponent<SpriteRenderer>();

            // vérifie que le composant existe
            if (playerRenderer != null)
            {
                // change le sprite du joueur pour le skin de faux
                playerRenderer.sprite = fakeSkin;
            }
        }
    }
}
