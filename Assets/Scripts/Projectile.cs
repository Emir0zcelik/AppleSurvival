using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        rb.velocity = transform.right * speed;
        

        if (speed > 0)
        {
            speed -= Time.deltaTime * 6;
        }

        if (speed < 0)
        {
            speed += Time.deltaTime * 6;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            speed = -5f;
        }
    }


}
