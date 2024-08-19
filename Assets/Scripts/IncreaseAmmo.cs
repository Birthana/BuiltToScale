public class IncreaseAmmo : Option
{
    public int size;

    public override void Buy()
    {
        FindObjectOfType<Ammo>().IncreaseSize(size);
    }
}
