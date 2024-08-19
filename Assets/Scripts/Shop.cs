using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject optionsPanel;

    private void Start()
    {
        Close();
    }

    public void Toggle()
    {
        if (IsOpen())
        {
            Close();
            return;
        }

        Open();
    }

    public bool IsOpen() { return optionsPanel.activeSelf; }

    public void Open()
    {
        optionsPanel.SetActive(true);
    }

    public void Close()
    {
        optionsPanel.SetActive(false);
    }
}
