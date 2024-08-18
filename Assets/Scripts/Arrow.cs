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
        var results = new List<Collider2D>();
        var filter = new ContactFilter2D();
        filter.SetLayerMask(1 << LayerMask.NameToLayer("Creature"));
        if (hitBox.OverlapCollider(filter, results) > 0)
        {
            var firstCreature = results[0].gameObject.GetComponent<Creature>();
            firstCreature.TakeDamage(GetDamage());
            Destroy(gameObject);
        }
    }

    private int GetDamage()
    {
        return (int)(baseDamage * GetDamageMultiplier());
    }

    private float GetDamageMultiplier()
    {
        var rng = Random.Range(0, (int)(100 / critPercentage));
        if (rng == 0)
        {
            Debug.Log("Crit.");
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

    private Vector3 GetDirection()
    {
        var rawDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        return rawDirection.normalized;
    }

    private void SetSpeed()
    {
        var direction = GetDirection();
        rb.velocity = direction * arrowSpeed;
    }

    private void SetAngle()
    {
        var angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private bool OffScreen()
    {
        var results = new List<Collider2D>();
        var filter = new ContactFilter2D();
        filter.SetLayerMask(1 << LayerMask.NameToLayer("OffScreen"));
        return hitBox.OverlapCollider(filter, results) > 0;
    }
}
