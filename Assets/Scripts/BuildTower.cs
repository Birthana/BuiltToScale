using System.Collections;
using UnityEngine;

public class BuildTower : Option
{
    public GameObject towerPrefab;
    public GameObject towerCheckPrefab;
    public float fixedTowerOffset;

    public override void Buy()
    {
        StartCoroutine(Picking());
    }

    private IEnumerator Picking()
    {
        var picking = true;
        FindObjectOfType<Shop>().Close();
        yield return new WaitForSeconds(0.1f);
        while(picking)
        {
            if (Input.GetMouseButtonDown(0) && CanPlace())
            {
                picking = false;
                var tower = Instantiate(towerPrefab);
                tower.transform.position = GetPosition();
            }

            yield return null;
        }
    }

    private Vector2 GetPosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(mousePosition.x, fixedTowerOffset);
    }

    private bool CanPlace()
    {
        var towerCheck = Instantiate(towerCheckPrefab);
        towerCheck.transform.position = GetPosition();
        var hitBox = towerCheck.GetComponent<BoxCollider2D>();

        if (IsOnTower(hitBox) || IsOnPlayer(hitBox) || IsOnDescend(hitBox) || IsOnAmmo(hitBox) || IsOnSugar(hitBox))
        {
            Destroy(towerCheck);
            return false;
        }

        Destroy(towerCheck);
        return true;
    }

    private bool IsOnTower(BoxCollider2D hitBox) { return IsOnLayer(hitBox, "Tower"); }

    private bool IsOnPlayer(BoxCollider2D hitBox) { return IsOnLayer(hitBox, "Player"); }

    private bool IsOnDescend(BoxCollider2D hitBox) { return IsOnLayer(hitBox, "Down"); }

    private bool IsOnAmmo(BoxCollider2D hitBox) { return IsOnLayer(hitBox, "Ammo"); }

    private bool IsOnSugar(BoxCollider2D hitBox) { return IsOnLayer(hitBox, "Sugar"); }

    private bool IsOnLayer(BoxCollider2D hitBox, string layer)
    {
        var hit = Physics2D.OverlapBoxAll(GetPosition(), hitBox.size, 0, 1 << LayerMask.NameToLayer(layer));
        Debug.Log($"{hit.Length}");
        return hit.Length > 0;
    }
}
