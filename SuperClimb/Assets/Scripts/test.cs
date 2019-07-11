using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("portalO") || collision.gameObject.CompareTag("portalB"))
        {
            Debug.Log("Destruiu");
            collision.gameObject.transform.position = new Vector2(0f, 325f);
        }
    }
}
