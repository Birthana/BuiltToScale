using UnityEngine;

public class Tower : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Health>().OnDeath += Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
