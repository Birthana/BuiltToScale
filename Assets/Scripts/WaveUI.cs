using UnityEngine;
using TMPro;


public class WaveUI : MonoBehaviour
{
    public TextMeshPro ui;

    public void SetText(int wave)
    {
        ui.text = $"{wave}";
    }
}
