using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 1.5f);
    }
}
