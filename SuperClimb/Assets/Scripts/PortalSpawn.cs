using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawn : MonoBehaviour
{
    [SerializeField]
    private Transform prefabOrange;

    [SerializeField]
    private Transform prefabBlue;

    private void Start()
    {
        StartCoroutine(PortalControl());
    }

    private IEnumerator PortalControl()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(prefabOrange, new Vector2(0f, 2.0f), Quaternion.identity);
        //Instantiate(prefabBlue, new Vector2(0f, 4.0f), Quaternion.identity);

    }


}
