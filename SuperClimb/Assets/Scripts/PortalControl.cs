using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    private Vector2 portalMovement;
    private float velX = 0f;
    public float velY = 1f;
    private float y;


    private void Update()
    {
        y = transform.position.y;
        transform.Translate(Vector3.down * Time.deltaTime, Space.World);


        if(y < -6)
        {
            transform.transform.Translate(0f,13f,0f);
        }
    }


}
