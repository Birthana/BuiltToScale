using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    public TextMeshPro ui;

    private void Awake()
    {
        GetComponentInParent<Gold>().OnChange += SetText;
    }

    private void SetText(int gold)
    {
        ui.text = $"{gold}";
    }
}
