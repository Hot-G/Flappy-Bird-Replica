using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Rigidbody2D rb;

    public GameManager gameManager;
    public float JumpSpeed = 2.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (!gameManager.isStarted)
            {
                gameManager.StartGame();
                rb.gravityScale = 1;
            }

            rb.velocity = Vector2.up * JumpSpeed;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rb.velocity.y * 12, -40, 40));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "DeadZone")
        {
            gameManager.EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PointZone")
        {
            gameManager.AddScore();
        }
    }
}
