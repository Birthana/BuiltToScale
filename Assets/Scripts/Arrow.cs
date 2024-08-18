using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
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
        SetAngle();
        Delete();
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

    private Vector2 GetDirection()
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
