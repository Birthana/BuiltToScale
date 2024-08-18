using System.Collections;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public float runSpeed;
    public float pauseTime;
    private Rigidbody2D rb;
    private Health health;
    private bool isPaused = false;

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

    public void TakeDamage(int damage, bool isCrit)
    {
        health.TakeDamage(damage, isCrit);
        Pause();
    }

    public void Pause()
    {
        isPaused = true;
        rb.velocity = Vector2.zero;
        StartCoroutine(Pausing());
    }

    private IEnumerator Pausing()
    {
        yield return new WaitForSeconds(pauseTime);
        isPaused = false;
    }

    private void Move()
    {
        if (isPaused)
        {
            return;
        }

        var horizontalSpeed = runSpeed;
        rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
