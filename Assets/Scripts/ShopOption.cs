using UnityEngine;
using TMPro;

public class ShopOption : MonoBehaviour
{
    public Option option;
    public int goldValue;
    public TextMeshPro description;
    public TextMeshPro cost;
    private int currentGoldValue;

    private void Awake()
    {
        currentGoldValue = goldValue;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsOnOption() && HasGold())
        {
            FindObjectOfType<Gold>().Spend(currentGoldValue);
            IncreaseCost();
            option.Buy();
        }
    }

    private void IncreaseCost()
    {
        currentGoldValue *= 3;
        cost.text = $"{currentGoldValue}";
    }

    private bool HasGold()
    {
        return FindObjectOfType<Gold>().Has(currentGoldValue);
    }

    private bool IsOnOption()
    {
        return IsHittingOption() && IsClicked();
    }

    private bool IsHittingOption()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = Physics2D.Raycast(ray.origin, Vector2.zero, 100, 1 << LayerMask.NameToLayer("Option"));
        return hit;
    }

    private bool IsClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = Physics2D.Raycast(ray.origin, Vector2.zero, 100, 1 << LayerMask.NameToLayer("Option"));
        var option = hit.transform.GetComponent<ShopOption>();
        if (option == null)
        {
            return false;
        }

        return option.gameObject.Equals(gameObject);
    }
}
