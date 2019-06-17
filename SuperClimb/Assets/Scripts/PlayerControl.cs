using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private float jSpeed = 5f;
    private float mSpeed = 6f;
    private int countJump = 0;
    private int maxCountJump = 2;
    private bool JumpNow = false;


    private Rigidbody2D rb;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject explosionO;

    [SerializeField]
    private GameObject explosionB;

    [SerializeField]
    private GameObject BlueSprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer.enabled = true;

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
        if (JumpNow && countJump < maxCountJump)
        {
            rb.velocity = new Vector2(mSpeed, jSpeed);
            mSpeed *= -1;
            countJump++;
            JumpNow = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TRAP COLLISION

        //OrangeTrap Collision if player is Orange
        if (collision.gameObject.tag == "TrapO" && spriteRenderer.enabled == true)
        {
            Instantiate(explosionO, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

        //OrangeTrap Collision if player is Blue
        else if (collision.gameObject.tag == "TrapO" && spriteRenderer.enabled == false)
        {
            Instantiate(explosionB, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        //BlueTrap Collision if player is Blue
        if (collision.gameObject.tag == "TrapB" && spriteRenderer.enabled == false)
        {
            Instantiate(explosionB, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        //BlueTrap Collision if player is Orange
        else if (collision.gameObject.tag == "TrapB" && spriteRenderer.enabled == true)
        {
            Instantiate(explosionO, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        //SWITCH SPRITE WHEN COLLIDE WHITH BLUE PORTALS
        if (collision.gameObject.tag == "portalB" && spriteRenderer.enabled == false)
        {

        }
        if (collision.gameObject.tag == "portalB" && spriteRenderer.enabled == true)
        {
            spriteRenderer.enabled = false;

        }
        //SWITCH SPRITE WHEN COLLIDE WHITH ORANGE PORTALS

        if (collision.gameObject.tag == "portalO" && spriteRenderer.enabled == true)
        {

        }
        if (collision.gameObject.tag == "portalO" && spriteRenderer.enabled == false)
        {
            spriteRenderer.enabled = true;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "oSide" || collision.gameObject.tag == "bSide")
        {
            ResetJump();
        }
    }
    private void ResetJump()
    {
        countJump = 0;
    }
}