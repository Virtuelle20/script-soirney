using UnityEngine;

public class BoutonOpenDoor : MonoBehaviour
{
    public GameObject objectToDestroye;
    public Sprite fakeSkin; // le skin de faux à vérifié

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpriteRenderer playerSprite = collision.GetComponent<SpriteRenderer>();
            if (playerSprite.sprite == fakeSkin)
            {
                Destroy(objectToDestroye);
            }
        }
    }
}
