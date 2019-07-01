using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWorldController : MonoBehaviour
{
    [SerializeField]
    GameObject portalB;

    [SerializeField]
    GameObject portalO;

    private bool destroyit = false;
    void Update()
    {
        if (destroyit)
        {
            Destroy(portalB.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "portalB")
        {
            destroyit = true;
        }
    }
}
