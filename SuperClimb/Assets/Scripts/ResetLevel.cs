using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    private bool StartCountReset = false;
    public float countReset = 0f;
    private float maxCountReset = 100f;

    void Start()
    {
        countReset = 0f;
    }

    void Update()
    {
        if (StartCountReset)
        {
            countReset++;
        }

        if (countReset == maxCountReset)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCountReset = true;
        }
    }
}
