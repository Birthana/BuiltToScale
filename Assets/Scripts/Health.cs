using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int, int> OnChange;
    public event Action<int, bool> OnDamage;
    public event Action OnDeath;
    public int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage, bool isCrit)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        OnDamage?.Invoke(damage, isCrit);
        OnChange?.Invoke(currentHealth, maxHealth);

        if (currentHealth == 0)
        {
            OnDeath?.Invoke();
        }
    }
}
