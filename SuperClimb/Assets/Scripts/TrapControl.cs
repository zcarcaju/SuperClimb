using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    [SerializeField]
    private float y;

    private void Update()
    {
        y = transform.position.y;
        transform.Translate(Vector3.down *-1 * Time.deltaTime * 0.1f, Space.World);
    }

}