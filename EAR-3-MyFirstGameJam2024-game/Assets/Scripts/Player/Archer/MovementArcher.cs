using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArcher : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float horizontal, vertical;
    public bool canMove = true;
    [SerializeField] private float speed;
    public string direction;
    [SerializeField] private PentruAnimatiiArcher animScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator>();
          Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        Cursor.visible = true;
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

        Vector3 pointerInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDirection = pointerInput - transform.position;

        RotateToPointer(lookDirection);  
    }
    private void RotateToPointer(Vector3 lookDirection)
    {
        Vector3 scale = transform.GetChild(0).localScale;
        if(!animScript.isAttacking)
        {
            if (lookDirection.x > 0)
            {
                scale.x = 1;
                direction = "right";
            }
            else if (lookDirection.x < 0)
            {
                scale.x = -1;
                direction = "left";
            }
            if (lookDirection.y > 1.2f && (lookDirection.x > -4.5f && lookDirection.x < 4.5f))
            {
                direction = "up";
            }
            else if (lookDirection.y < -0.7f && (lookDirection.x > -4.5f && lookDirection.x < 4.5f))
            {
                direction = "down";
            }
            Debug.Log(lookDirection.x);
           /*if (Input.GetAxisRaw("Mouse X") > 0.2f)
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
                direction = "up";*/
        }
        transform.GetChild(0).localScale = scale;
    }
}
