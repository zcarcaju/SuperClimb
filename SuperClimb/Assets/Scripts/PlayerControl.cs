using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float x = 0;
    float y=0;
    private float jSpeed = 4f;
    private float mSpeed = 4f;
    private bool JumpNow = false;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        Jump();
    }
    private void Update()
    {
        
        IsJumping();
    }
    private void IsJumping()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            JumpNow = true;   
        } 
    }
    private void Jump()
    {
        if (JumpNow)
        {
            
            
            rb.velocity = new Vector2(mSpeed, jSpeed);
            mSpeed *= -1;
            JumpNow = false;
        }
    }
}