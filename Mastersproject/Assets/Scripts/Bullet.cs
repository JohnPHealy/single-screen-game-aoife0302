using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    private void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyPatrol>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Box")
            {
                Destroy(collision.gameObject);
            }
    }
}
