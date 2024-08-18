using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private int baseDamage;
    [SerializeField] private float critPercentage;
    [SerializeField] private float critMultiplier;
    [SerializeField] private float arrowSpeed;
    private Rigidbody2D rb;
    private BoxCollider2D hitBox;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Hit();
        SetAngle();
        Delete();
    }

    private void Hit()
    {
        var collisions = Utility.GetCollisions(hitBox, "Creature");
        if (collisions.Count > 0)
        {
            var firstCreature = collisions[0].gameObject.GetComponent<Creature>();
            var multiplier = GetDamageMultiplier();
            var damage = (int)(baseDamage * multiplier);
            var isCrit = multiplier == critMultiplier;
            firstCreature.TakeDamage(damage, isCrit);
            Destroy(gameObject);
        }
    }

    private float GetDamageMultiplier()
    {
        var rng = Random.Range(0, (int)(100 / critPercentage));
        if (rng == 0)
        {
            return critMultiplier;
        }

        return 1.0f;
    }

    private void Delete()
    {
        if (OffScreen())
        {
            Destroy(gameObject);
        }
    }

    public void Set()
    {
        SetSpeed();
        SetAngle();
    }

    private void SetSpeed()
    {
        Vector2 click = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var direction = click / click.magnitude;
        rb.velocity = direction * arrowSpeed;
    }

    private void SetAngle()
    {
        var angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private bool OffScreen()
    {
        return Utility.GetCollisions(hitBox, "OffScreen").Count > 0;
    }
}
