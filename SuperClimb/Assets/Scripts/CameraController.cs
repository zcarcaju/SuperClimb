using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    private float moveSpeed = 0f;
    [SerializeField]
    private Transform target;

    void Update()
    {
        Vector3 newPosition =
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }

}