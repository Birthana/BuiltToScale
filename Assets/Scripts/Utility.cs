using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static List<Collider2D> GetCollisions(BoxCollider2D hitBox, string layer)
    {
        var results = new List<Collider2D>();
        var filter = new ContactFilter2D();
        filter.SetLayerMask(1 << LayerMask.NameToLayer(layer));
        if (hitBox.OverlapCollider(filter, results) > 0)
        {
            return results;
        }

        return new List<Collider2D>();
    }
}
