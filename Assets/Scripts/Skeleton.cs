using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private int skeletonHealth = 1;
    private bool damageTaken = false;

    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Vector3 exPos;
    private bool m_FacingRight = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        exPos = transform.position;
    }

    private void Update()
    {
        
        SkelletonAnimation();

    }

    private void SkelletonAnimation()
    {
        if (damageTaken)
        {
            anim.SetBool("DamageTaken", true);
        }

        if (!damageTaken)
        {
            anim.SetBool("DamageTaken", false);
        }

        if (transform.position.x > exPos.x && m_FacingRight)
        {
            anim.SetBool("isWalking", true);
            Flip();
        }

        if (transform.position.x > exPos.x && !m_FacingRight)
        {
            anim.SetBool("isWalking", true);

        }

        if (transform.position.x < exPos.x && !m_FacingRight)
        {
            anim.SetBool("isWalking", true);
            Flip();
        }

        if (transform.position.x < exPos.x && m_FacingRight)
        {
            anim.SetBool("isWalking", true);

        }

        if (transform.position.x == exPos.x)
        {
            anim.SetBool("isWalking", false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            if (skeletonHealth != 0)
            {
                damageTaken = true;
                anim.SetBool("DamageTaken", true);
                skeletonHealth--;
            }

            else
            {
                Destroy(gameObject);
            }
        }

        damageTaken = false;
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
