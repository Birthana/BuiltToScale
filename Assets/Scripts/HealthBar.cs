using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        GetComponentInParent<Health>().OnChange += ChangeScale;
        GetComponentInParent<Health>().OnChange += ChangeColor;
    }

    private void ChangeScale(int current, int max)
    {
        var scale = (float)current / max;
        transform.localScale = new Vector2(scale, 1);
    }

    private void ChangeColor(int current, int max)
    {
        var scale = (float)current / max;
        if (scale <= 0.5f)
        {
            sprite.color = Color.red;
        }
    }
}
