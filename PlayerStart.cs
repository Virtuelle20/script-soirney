using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public Sprite defaultPlayerSprite;
    public Sprite newPlayerSprite;


    void Start()
    {
        // Trouve le joueur et applique le sprite par défaut
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<SpriteRenderer>().sprite = defaultPlayerSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tunictuto"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.GetComponent<SpriteRenderer>().sprite = newPlayerSprite;
            }
        }
    }
}
