using UnityEngine;

public class TeleportTunic : MonoBehaviour
{
    public Sprite skin; // Le skin s�lectionn�
    public Transform target; // La cible de t�l�portation
    public float cooldown = 1f; // Temps de recharge en secondes
    private bool canTeleport = true; // Variable qui indique si la t�l�portation est possible ou non
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canTeleport && skin != null && spriteRenderer.sprite == skin)
            {
                transform.position = target.position;
                canTeleport = false; // D�sactiver la t�l�portation
                Invoke("ActivateTeleport", cooldown); // Activer la t�l�portation apr�s le temps de recharge
            }
        }
    }

    private void ActivateTeleport()
    {
        canTeleport = true; // R�activer la t�l�portation
    }
}
