using UnityEngine;

public class SkipIntro : MonoBehaviour
{
    public Transform target;  // définir la cible à partir de l'éditeur Unity

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))  // vérifier si la touche "Tab" est appuyée
        {
            transform.position = target.position;  // téléporter l'entité à la position de la cible
        }
    }
}
