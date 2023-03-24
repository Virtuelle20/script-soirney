using UnityEngine;

public class SkipIntro : MonoBehaviour
{
    public Transform target;  // d�finir la cible � partir de l'�diteur Unity

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))  // v�rifier si la touche "Tab" est appuy�e
        {
            transform.position = target.position;  // t�l�porter l'entit� � la position de la cible
        }
    }
}
