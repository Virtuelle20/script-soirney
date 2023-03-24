using UnityEngine;

public class TeleportTunic : MonoBehaviour
{
    public Sprite skin; // Le skin sélectionné
    public Transform target; // La cible de téléportation
    public float cooldown = 1f; // Temps de recharge en secondes
    public float maxSpeed = 10f; // Vitesse maximale autorisée pour la téléportation
    private bool canTeleport = true; // Variable qui indique si la téléportation est possible ou non
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canTeleport && skin != null && spriteRenderer.sprite == skin && GetComponent<Rigidbody2D>().velocity.magnitude <= maxSpeed)
            {
                transform.position = target.position;
                canTeleport = false; // Désactiver la téléportation
                Invoke("ActivateTeleport", cooldown); // Activer la téléportation après le temps de recharge
            }
        }
    }

    private void ActivateTeleport()
    {
        canTeleport = true; // Réactiver la téléportation
    }
}
