using System.Collections.Generic;
using UnityEngine;

public class AmmoBar : MonoBehaviour
{
    public Ammo ammo;
    public GameObject ammoUIPrefab;
    public float spacing;
    private List<GameObject> ammoUIs = new List<GameObject>();

    private void Awake()
    {
        ammo.OnChange += SpawnUI;
    }

    public void SpawnUI(int ammo)
    {
        Reset();
        for (int i = 0; i < ammo; i++)
        {
            var ammoUI = Instantiate(ammoUIPrefab, transform);
            ammoUIs.Add(ammoUI);
        }

        Display();
    }

    private void Reset()
    {
        for(int i = 0; i < ammoUIs.Count; i++)
        {
            Destroy(ammoUIs[i]);
        }

        ammoUIs = new List<GameObject>();
    }

    private void Display()
    {
        for (int i = 0; i < ammoUIs.Count; i++)
        {
            ammoUIs[i].transform.position = GetHorizontalOffsetPositionAt(i);
        }
    }

    public Vector3 GetHorizontalOffsetPositionAt(int index)
    {
        float x = transform.position.x + GetOffset(index);
        return new Vector3(x, transform.position.y, transform.position.z);
    }

    private float GetOffset(int index)
    {
        return index * spacing * 0.5f;
    }
}
