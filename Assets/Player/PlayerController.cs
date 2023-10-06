using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static string gameState = "playing";

    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f;
    public float jump = 8.0f;
    public LayerMask groundLayer;
    bool onGround = false;
    bool goJump = false;

    Animator animator;
    public string[] animations;
    string cur_Anime = "";
    string pre_Anime = "";

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cur_Anime = animations[0];
        pre_Anime = animations[0];
        gameState = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState != "playing")
        {
            return;
        }

        axisH = Input.GetAxis("Horizontal");

        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        goJump = true;
    }

    private void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }

        onGround = Physics2D.Linecast(transform.position, transform.position - transform.up * 0.1f, groundLayer);
        if(onGround || axisH != 0)
        {
            rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
        }

        if(onGround && goJump)
        {
            rbody.velocity = new(rbody.velocity.x, 0);
            Vector2 jumpPw = new(0,jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }

        if (!onGround)
        {
            goJump = false;
        }

        if (onGround)
        {
            if(axisH == 0)
            {
                cur_Anime = animations[0];
            }
            else
            {
                cur_Anime = animations[2];
            }
        }
        else
        {
            cur_Anime = animations[1];
        }

        if(cur_Anime != pre_Anime)
        {
            pre_Anime = cur_Anime;
            animator.Play(cur_Anime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Goal")
        {
            Goal();
        }
        else if(collision.tag == "Dead")
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameState = "GameOver";
        animator.Play(animations[4]);
        GetComponent<CapsuleCollider2D>().enabled = false;
        GameEnd();
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    private void Goal()
    {
        gameState = "GameClear";
        animator.Play(animations[3]);
        GameEnd();
    }

    void GameEnd()
    {
        rbody.velocity = new(0, 0);
    }
}
