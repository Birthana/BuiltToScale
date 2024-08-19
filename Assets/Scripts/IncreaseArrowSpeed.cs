public class IncreaseArrowSpeed : Option
{
    public float speed;

    public override void Buy()
    {
        FindObjectOfType<Shooting>().IncreaseArrowSpeed(speed);
    }
}
