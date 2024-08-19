using UnityEngine;

public class ReduceReloadTime : Option
{
    public float time;

    public override void Buy()
    {
        FindObjectOfType<Shooting>().ReduceReload(time);
    }
}
