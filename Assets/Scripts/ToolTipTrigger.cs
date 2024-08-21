using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        FindObjectOfType<ToolTipSystem>().Show(text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FindObjectOfType<ToolTipSystem>().Hide();
    }
}
