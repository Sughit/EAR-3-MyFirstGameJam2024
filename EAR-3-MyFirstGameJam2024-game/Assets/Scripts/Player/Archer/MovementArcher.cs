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
    [SerializeField] private GameObject right, up, down, left;
    Vector2 moveDirection;
    public bool isDashing = false;

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

        moveDirection = new Vector2(horizontal, vertical).normalized;
        Vector3 scale = transform.localScale;

        if(canMove && !animScript.isAttacking)
        {
            if(Input.GetKeyDown(KeyCode.Space) && !isDashing && moveDirection != Vector2.zero)
            {
                if(horizontal > 0)
                    right.SetActive(true);
                else if(horizontal < 0)
                    left.SetActive(true);
                else if(vertical > 0)
                    up.SetActive(true);
                else if(vertical < 0)
                    down.SetActive(true);
                StartCoroutine(Dash());  
            }

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
        }
        transform.GetChild(0).localScale = scale;
    }

    IEnumerator Dash()
    {
        isDashing = true;
        anim.SetTrigger("dash");
        rb.AddForce(moveDirection *  100f);

        yield return new WaitForSeconds(0.16f);

        right.SetActive(false);
        up.SetActive(false);
        down.SetActive(false);
        left.SetActive(false);

        yield return new WaitForSeconds(0.65f);
        isDashing = false;
    }
}
