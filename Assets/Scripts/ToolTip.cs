using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI description;
    public LayoutElement layoutElement;
    public int characterWrapLimit;
    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void SetText(string text)
    {
        description.text = text;
        layoutElement.enabled = description.text.Length > characterWrapLimit;
    }

    private void Update()
    {
        Vector2 positon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float pivotX = positon.x / Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        float pivotY = positon.y / Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        rect.pivot = new Vector2(pivotX, pivotY);
        transform.position = positon;
    }
}
