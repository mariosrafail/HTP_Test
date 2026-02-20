using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= 7f)
        {
            anim.SetBool("goUp", true);
            //rb.velocity = new Vector2(rb.velocity.x, 3f);
        }else
        {
            anim.SetBool("goUp", false);
        }
    }
}
