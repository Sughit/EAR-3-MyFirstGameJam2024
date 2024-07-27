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
    public string direction;
    [SerializeField] private PentruAnimatii animScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        Vector3 scale = transform.localScale;
        if(canMove && !animScript.isAttacking)
        {
            rb.velocity = moveDirection * speed * Time.fixedDeltaTime;
            
            if (moveDirection != Vector2.zero)
                anim.SetBool("sideRunning", true);
            else
                anim.SetBool("sideRunning", false);
        }
        else
            rb.velocity = Vector2.zero;
            Debug.Log(direction);
            RotateToPointer();
    }
    private void RotateToPointer()
    {
        Vector3 scale = transform.GetChild(0).localScale;
        if(!animScript.isAttacking)
        {
           if (Input.GetAxisRaw("Mouse X") > 0.2f)
            {
                scale.x = 1;
                direction = "right";
            }
            if (Input.GetAxisRaw("Mouse X") < -0.2f)
            {
                scale.x = -1;
                direction = "left";
            }
            if(Input.GetAxisRaw("Mouse Y") < -0.2f)
                direction = "down";
            if(Input.GetAxisRaw("Mouse Y") > 0.2f)
                direction = "up";
        }
        transform.GetChild(0).localScale = scale;
    }
}
