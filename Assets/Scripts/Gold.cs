using System;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public event Action<int> OnChange;
    [SerializeField]private int goldAmount;

    private void Start()
    {
        OnChange?.Invoke(goldAmount);
    }

    public void Add(int gold)
    {
        goldAmount += gold;
        OnChange?.Invoke(goldAmount);
    }

    public void Spend(int gold)
    {
        goldAmount = Mathf.Max(0, goldAmount - gold);
        OnChange?.Invoke(goldAmount);
    }

    public bool Has(int gold)
    {
        return goldAmount >= gold;
    }
}
