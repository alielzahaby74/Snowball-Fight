using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 20f;
    public float defaultScale;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    public GameObject snowBall;
    public Transform throwPoint;

    public AudioSource throwSound;

    private Rigidbody2D rb;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        Jump();
        Shoot();
    }
    void Move()
    {
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(-1 * defaultScale, transform.localScale.y, 0);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(1 * defaultScale, transform.localScale.y, 0);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (Input.GetKey(jump) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        anim.SetBool("Grounded", isGrounded);
    }
    void Shoot()
    {
        if(Input.GetKeyDown(throwBall))
        {
            GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");

            throwSound.Play();
        }
    }
}