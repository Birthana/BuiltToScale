using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public float runSpeed;
    public float pauseTime;
    public float attackCooldown;
    public int goldValue;
    protected Rigidbody2D rb;
    protected BoxCollider2D hitBox;
    private Health health;
    protected bool isPaused = false;
    private bool isOnCooldown = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<BoxCollider2D>();
        health = GetComponent<Health>();
        health.OnDeath += Die;
    }

    protected void SetAngle()
    {
        var angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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

    protected void MoveLeft()
    {
        var horizontalSpeed = runSpeed;
        SetVelocity(new Vector2(horizontalSpeed, 0));
        SetAngle();
    }

    protected void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    private void Die()
    {
        FindObjectOfType<Gold>().Add(goldValue);
        Destroy(gameObject);
    }

    protected void Attack()
    {
        if (CanAttack() && !isOnCooldown)
        {
            isOnCooldown = true;
            var results = Utility.GetCollisions(hitBox, "Sugar");
            results[0].GetComponent<Health>().TakeDamage(1, false);
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        isOnCooldown = false;
    }

    private bool CanAttack()
    {
        return Utility.GetCollisions(hitBox, "Sugar").Count > 0;
    }

    protected void Climb()
    {
        if (CanClimb())
        {
            var vertical = runSpeed;
            SetVelocity(new Vector2(0, vertical));
            SetAngle();
        }
    }

    private bool CanClimb()
    {
        return Utility.GetCollisions(hitBox, "Climbable").Count > 0;
    }

    protected bool IsClimbing()
    {
        return rb.velocity.y > 0 && CanClimb();
    }

    protected void Descend()
    {
        if (CanDescend())
        {
            var vertical = runSpeed * -1.0f;
            SetVelocity(new Vector2(0, vertical));
            SetAngle();
        }
    }

    private bool CanDescend()
    {
        return Utility.GetCollisions(hitBox, "Down").Count > 0;
    }

    protected bool IsDescending()
    {
        return rb.velocity.y < 0;
    }
}
