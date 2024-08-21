using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    public ToolTip toolTip;

    public void Show(string text)
    {
        toolTip.gameObject.SetActive(true);
        FindObjectOfType<ToolTip>().SetText(text);
    }

    public void Hide()
    {
        toolTip.gameObject.SetActive(false);
    }
}
