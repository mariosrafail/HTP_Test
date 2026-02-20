using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    private bool isColliding, isHunt1, isHunt2, isHunting, isAttacking;
    public LayerMask stopMask, playerMask;
    public float speed;
    public GameObject player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y), new Vector2(0.6f, 0.2f));

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x - 2.5f, gameObject.transform.position.y), new Vector2(3.4f, 2f));

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1.6f), new Vector2(0.6f, 4f));
    }

    void Update()
    {
        rb.velocity = new Vector2(speed * transform.localScale.x * -1, rb.velocity.y);

        isColliding = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x - (1f * transform.localScale.x), gameObject.transform.position.y),
            new Vector2(0.8f, 0.2f), 0f, stopMask);

        isAttacking = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x - (1f * transform.localScale.x), gameObject.transform.position.y),
            new Vector2(0.8f, 0.2f), 0f, playerMask);

        isHunt1 = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + (2.5f * transform.localScale.x), gameObject.transform.position.y),
            new Vector2(3.4f, 2f), 0f, playerMask);
        isHunt2 = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1.6f),
            new Vector2(0.6f, 4f), 0f, playerMask);

        if (isHunt1 || isHunt2)
        {
            isHunting = true;
        }
        else
        {
            isHunting = false;
        }

        if(isHunting)
        {
            if(player.transform.position.x > gameObject.transform.position.x + 0.1f)
            {
                transform.localScale = new Vector2(1f, transform.localScale.y);
                speed = 5;
            }
            else if (player.transform.position.x < gameObject.transform.position.x - 0.1f)
            {
                transform.localScale = new Vector2(-1f, transform.localScale.y);
                speed = 5;
            }
            else
            {
                speed = 0;
            }
        }else if (!isHunting)
        {
            speed = 2;
        }

        if (isColliding && !isHunting)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        }
        if((isColliding && isHunting) || isAttacking)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}
