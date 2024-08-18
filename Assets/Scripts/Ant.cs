using System.Collections.Generic;
using UnityEngine;

public class Ant : Creature
{
    private void Update()
    {
        if (isPaused)
        {
            return;
        }

        Attack();
        Descend();

        if (IsDescending())
        {
            return;
        }

        Climb();
        if (IsClimbing())
        {
            return;
        }

        MoveLeft();
    }
}
