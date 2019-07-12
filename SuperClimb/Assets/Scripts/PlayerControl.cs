using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{


    private float jSpeed = 5f; // Jump
    private float mSpeed = 6f; // Movement
    private int countJump = 0; // Jump count
    private int maxCountJump = 2; // Max jump count
    private bool JumpNow = false;

    public int score = 0;
    private int countScore = 0;

    public Vector2 velPlayer; // player movement control

    private bool reset = false; // reload game
    public bool Reset // aux to export var reset (reload game after secs)
    {
        get { return reset; }
        set { reset = value; }
    }
    private bool verJumpNow = true; // player can jump



    [SerializeField]
    Sprite orangeSprite; // player is orange

    [SerializeField]
    Sprite blueSprite; // player is blue

    private Rigidbody2D rb;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject explosionO; // orange particles

    [SerializeField]
    private GameObject explosionB; // blue particles


    private void Start()
    {
        
        score = 0;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer.sprite = orangeSprite;
        velPlayer.x = mSpeed;
        velPlayer.y = jSpeed;
        Physics2D.IgnoreLayerCollision(8, 9, false);

    }
    private void FixedUpdate()
    {
        Jump();
    }
    private void Update()
    {
        IsJumping();

        countScore = (int)transform.position.y;
        score = countScore;
    }

    private void IsJumping() // if true, player can jump
    {
        if (Input.GetMouseButtonDown(0) && verJumpNow)
        {
            JumpNow = true;
        }
    }
    private void Jump() // jump components
    {
        if (verJumpNow && JumpNow && countJump < maxCountJump)
        {
            rb.velocity = new Vector2(mSpeed, jSpeed);
            mSpeed *= -1; // invert side movement
            countJump++; // +1 jump count
            JumpNow = false; // can't jump if is false
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Conditions

        //Floor Collision
        if (collision.gameObject.tag == "Floor" && spriteRenderer.sprite == orangeSprite)
        {
            
            velPlayer = Vector2.zero;
            countJump = maxCountJump;
            verJumpNow = false;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            Instantiate(explosionO, transform.position, Quaternion.identity);
            spriteRenderer.color = Color.clear;
            Physics2D.IgnoreLayerCollision(8, 10, true);
            StartCoroutine(resetPlayer());
        }

        if (collision.gameObject.tag == "Floor" && spriteRenderer.sprite == blueSprite)
        {
            
            velPlayer = Vector2.zero;
            countJump = maxCountJump;
            verJumpNow = false;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            Instantiate(explosionB, transform.position, Quaternion.identity);
            spriteRenderer.color = Color.clear;
            Physics2D.IgnoreLayerCollision(8, 10, true);
            StartCoroutine(resetPlayer());
        }

        //TRAP COLLISION 
        //OrangeTrap Collision if player is Orange
        if (collision.gameObject.tag == "TrapO" && spriteRenderer.sprite == orangeSprite)
        {
            Physics2D.IgnoreLayerCollision(8, 9, true); // ignore collision with layers to prevent bugs
            velPlayer = Vector2.zero; // stop player movement
            countJump = maxCountJump; // player can't jump
            verJumpNow = false; // player can't jump
            rb.gravityScale = 0f; // stop player movement
            rb.velocity = Vector2.zero; // stop player movement
            Instantiate(explosionO, transform.position, Quaternion.identity); // instantiate particles when die
            spriteRenderer.color = Color.clear; // switch sprite do alpha 0
            StartCoroutine(resetPlayer()); // reload game
        }

        //OrangeTrap Collision if player is Blue
        else if (collision.gameObject.tag == "TrapO" && spriteRenderer.sprite == blueSprite)
        {
            
            Physics2D.IgnoreLayerCollision(8, 9, true);
            velPlayer = Vector2.zero;
            countJump = maxCountJump;
            verJumpNow = false;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            Instantiate(explosionB, transform.position, Quaternion.identity);
            spriteRenderer.color = Color.clear;
            StartCoroutine(resetPlayer());
        }
        //BlueTrap Collision if player is Blue
        if (collision.gameObject.tag == "TrapB" && spriteRenderer.sprite == blueSprite)
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            velPlayer = Vector2.zero;
            countJump = maxCountJump;
            verJumpNow = false;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            Instantiate(explosionB, transform.position, Quaternion.identity);
            spriteRenderer.color = Color.clear;
            StartCoroutine(resetPlayer());
        }

        //BlueTrap Collision if player is Orange
        else if (collision.gameObject.tag == "TrapB" && spriteRenderer.sprite == orangeSprite)
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            velPlayer = Vector2.zero;
            countJump = maxCountJump;
            verJumpNow = false;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            Instantiate(explosionO, transform.position, Quaternion.identity);
            spriteRenderer.color = Color.clear;
            StartCoroutine(resetPlayer());
        }

        //COLLISION SIDES

        //OrangeSide Collision if player is Blue
        if (collision.gameObject.tag == "oSide" && spriteRenderer.sprite == blueSprite)
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            velPlayer = Vector2.zero;
            countJump = maxCountJump;
            verJumpNow = false;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            Instantiate(explosionB, transform.position, Quaternion.identity);
            spriteRenderer.color = Color.clear;
            StartCoroutine(resetPlayer());  
        }


        //BlueSide Collision if player is Orange
        if (collision.gameObject.tag == "bSide" && spriteRenderer.sprite == orangeSprite)
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            velPlayer = Vector2.zero;
            countJump = maxCountJump;
            verJumpNow = false;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            Instantiate(explosionO, transform.position, Quaternion.identity);
            spriteRenderer.color = Color.clear;
            StartCoroutine(resetPlayer());
        }

        //SWITCH SPRITE WHEN COLLIDE WHITH BLUE PORTALS
        if (collision.gameObject.tag == "portalB" && spriteRenderer.sprite == orangeSprite)
        {
            spriteRenderer.sprite = blueSprite;

        }
        //SWITCH SPRITE WHEN COLLIDE WHITH ORANGE PORTALS


        if (collision.gameObject.tag == "portalO" && spriteRenderer.sprite == blueSprite)
        {
            spriteRenderer.sprite = orangeSprite;

        }
    }
    // reset game after 1.5 sec
    private IEnumerator resetPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
        
    }
    
    // Condition to reset jumpcount after collision with sides
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "oSide" || collision.gameObject.tag == "bSide")
        {
            ResetJump();
        }
    }
    // Reset jumpcount
    private void ResetJump()
    {
        countJump = 0;
    }
}