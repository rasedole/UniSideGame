using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 3f;
    Vector2 direction;
    Vector3 groundCheckPosition;
    Rigidbody2D rb;
    bool onGround = false;
    public LayerMask groundLayer;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = Vector2.left;
        groundCheckPosition = new Vector3(1, 0, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = speed * direction;
        onGround = Physics2D.Linecast(transform.position - groundCheckPosition, transform.position - transform.up * 0.1f - groundCheckPosition, groundLayer);
        if (onGround == false)
        {
            rb.velocity = Vector2.zero;
            direction *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
            groundCheckPosition *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(PlayerController.gameState == "playing")
            {
                collision.gameObject.GetComponent<PlayerController>().GameOver();
            }
        }
    }
}
