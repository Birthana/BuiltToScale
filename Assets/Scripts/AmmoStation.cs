using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoStation : MonoBehaviour
{
    private BoxCollider2D hitBox;

    private void Awake()
    {
        hitBox = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Refill();
    }

    private void Refill()
    {
        var results = new List<Collider2D>();
        var filter = new ContactFilter2D();
        filter.SetLayerMask(1 << LayerMask.NameToLayer("Player"));
        if (hitBox.OverlapCollider(filter, results) > 0)
        {
            results[0].GetComponent<Ammo>().Refill();
        }
    }
}
