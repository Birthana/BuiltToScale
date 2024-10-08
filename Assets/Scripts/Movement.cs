using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private float runSpeed;
    [SerializeField] private float climbSpeed;
    private Rigidbody2D rb;
    private BoxCollider2D hitBox;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveLeftOrRight();
        MoveUpOrDown();
    }

    private void MoveLeftOrRight()
    {
        if (Input.GetButton("Horizontal"))
        {
            var direction = Input.GetAxis("Horizontal");
            var horizontalSpeed = direction * runSpeed;
            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
            PlayWalkAnimation(direction);
        }
    }

    private void PlayWalkAnimation(float direction)
    {
        if (direction >= 0)
        {
            anim.Play("Player_Walk_Right");
            return;
        }

        anim.Play("Player_Walk");
    }

    private void MoveUpOrDown()
    {
        if (Input.GetButton("Vertical") && CanClimb())
        {
            var direction = Input.GetAxis("Vertical");
            var verticalSpeed = direction * climbSpeed;
            rb.velocity = new Vector2(rb.velocity.x, verticalSpeed);
        }
    }

    private bool CanClimb()
    {
        var results = new List<Collider2D>();
        var filter = new ContactFilter2D();
        filter.SetLayerMask(1 << LayerMask.NameToLayer("Climbable"));
        return hitBox.OverlapCollider(filter, results) > 0;
    }
}
