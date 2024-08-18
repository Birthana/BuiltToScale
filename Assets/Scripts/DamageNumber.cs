using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public GameObject damageNumberPrefab;
    public float duration;
    public float speed;

    private void Awake()
    {
        GetComponent<Health>().OnDamage += Spawn;
    }

    public void Spawn(int damage, bool isCrit)
    {
        var damageNumber = Instantiate(damageNumberPrefab);
        damageNumber.transform.position = transform.position;
        damageNumber.GetComponent<TextMeshPro>().text = $"-{damage}";
        if (isCrit)
        {
            damageNumber.transform.localScale = new Vector2(2, 2);
            damageNumber.GetComponent<TextMeshPro>().color = Color.yellow;
        }

        damageNumber.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * speed * 10);
        Destroy(damageNumber, duration);
    }
}
