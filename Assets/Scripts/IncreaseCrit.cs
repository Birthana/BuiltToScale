public class IncreaseCrit : Option
{
    public float crit;

    public override void Buy()
    {
        FindObjectOfType<Shooting>().IncreaseCrit(crit);
    }
}
