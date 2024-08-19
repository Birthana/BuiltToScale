using System.Collections;
using UnityEngine;

public class BuildTower : Option
{
    public GameObject towerPrefab;
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
            if (Input.GetMouseButtonDown(0))
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
}
