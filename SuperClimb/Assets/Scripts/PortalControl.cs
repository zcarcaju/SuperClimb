using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    private Vector2 portalMovement;
    private float velX = 0f;

    [SerializeField]
    private float velY = 1f;
    [SerializeField]
    private float inicialRange;
    [SerializeField]
    private float finalRange;


    private float y;

    

    private void Update()
    {
        y = transform.position.y;
        transform.Translate(Vector3.down * Time.deltaTime, Space.World);


        if(y < -6)
        {
            transform.transform.Translate(0f, Random.Range(inicialRange, finalRange),0f);
        }
    }


}
