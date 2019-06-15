using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float moveSpeed = 0f;
    public Transform target; // Drop the player in the inspector of the camera

    void Update()
    {
        Vector3 newPosition =
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }
}