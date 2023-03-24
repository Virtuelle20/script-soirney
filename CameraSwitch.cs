using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public List<Camera> cameras;
    private int currentCameraIndex = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentCameraIndex++;
            if (currentCameraIndex >= cameras.Count)
            {
                currentCameraIndex = 0;
            }
            Destroy(cameras[currentCameraIndex - 1].gameObject);
        }
    }
}
