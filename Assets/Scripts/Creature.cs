using UnityEngine;

public class Creature : MonoBehaviour
{
    public float runSpeed;
    private Rigidbody2D rb;
    private Health health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        health.OnDeath += Die;
    }

    private void Update()
    {
        Move();
    }
    public void TakeDamage(int damage) { health.TakeDamage(damage); }

    private void Move()
    {
        var horizontalSpeed = runSpeed;
        rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
