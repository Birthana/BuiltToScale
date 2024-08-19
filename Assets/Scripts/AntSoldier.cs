public class AntSoldier : Creature
{ 
    private void Update()
    {
        if (isPaused)
        {
            return;
        }

        Attack();
        AttackTower();

        if (IsAttacking())
        {
            return;
        }

        MoveLeft();
    }
}
