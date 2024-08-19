using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public event Action<int> OnChange;
    public int maxSize;
    private int currentMaxSize;
    private int currentSize;

    private void Awake()
    {
        currentMaxSize = maxSize;
        Refill();
    }

    public void Refill()
    {
        currentSize = currentMaxSize;
        OnChange?.Invoke(currentSize);
    }

    public bool IsNotEmpty()
    {
        return currentSize != 0;
    }

    public void Use()
    {
        currentSize = Mathf.Max(0, currentSize - 1);
        OnChange?.Invoke(currentSize);
    }

    public void IncreaseSize(int size)
    {
        currentMaxSize += size;
    }
}
