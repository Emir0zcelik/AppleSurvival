using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private ItemCollector collector;

    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask deathFall;

    private enum movementState { idle, isWalking, isJump, isAttack}

    private float dirX = 0f;
    private float dirY = 0f;
    private bool isAttack = true;
    private bool m_FacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        collector = GetComponent<ItemCollector>();  
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        isAttack = true;

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        UpdateAnimation(dirX, dirY);
        
    }
    
    private void UpdateAnimation(float dirX, float dirY)
    {  
        if (dirY > 0f  && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("isJump", true);
        }

        if (dirY == 0f)
        {
            anim.SetBool("isJump", false);
        }

        if (dirX > 0f && !m_FacingRight)
        {
            anim.SetBool("isWalking", true);

            Flip();
        }

        if (dirX > 0f && m_FacingRight)
        {
            anim.SetBool("isWalking", true);
        }

        if (dirX < 0f && m_FacingRight)
        {
            anim.SetBool("isWalking", true);

            Flip();
        }

        if (dirX < 0f && !m_FacingRight)
        {
            anim.SetBool("isWalking", true);
        }

        if (dirX == 0f)
        {
            anim.SetBool("isWalking", false);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }

    public bool canAttack()
    {
        return  collector.appleCounter > 0;
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

}
