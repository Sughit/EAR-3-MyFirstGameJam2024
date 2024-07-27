using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float horizontal, vertical;
    public bool canMove = true;
    [SerializeField] private float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        Vector2 scale = transform.localScale;
        if(canMove)
        {
            rb.velocity = moveDirection * speed * Time.fixedDeltaTime;
            
            if (horizontal > 0)
            {
                scale.x = 1;
                anim.SetBool("sideRunning", true);
            }
            else if (horizontal < 0)
            {
                scale.x = -1;
                anim.SetBool("sideRunning", true);
            }
            else
                anim.SetBool("sideRunning", false);

            transform.localScale = scale;
        }
        else
            rb.velocity = Vector2.zero;

    }
}
