using UnityEngine;

public class ChangeSkinfakeOnTrigger : MonoBehaviour
{
    public Sprite fakeSkin; // le skin de faux � appliquer

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("skin_change"))
        {
            // r�cup�re le composant SpriteRenderer du joueur
            SpriteRenderer playerRenderer = collision.GetComponent<SpriteRenderer>();

            // v�rifie que le composant existe
            if (playerRenderer != null)
            {
                // change le sprite du joueur pour le skin de faux
                playerRenderer.sprite = fakeSkin;
            }
        }
    }
}
