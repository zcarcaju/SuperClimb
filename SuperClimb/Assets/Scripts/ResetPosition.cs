using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("portalO") || collision.gameObject.CompareTag("portalB"))
        {
            
            collision.gameObject.transform.position = new Vector2(0f, 325f);
        }
    }
}
