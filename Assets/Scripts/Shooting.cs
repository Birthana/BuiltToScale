using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Arrow arrowPrefab;
    [SerializeField]private float reloadTime;
    private bool reloading = false;
    private Ammo ammo;

    private void Awake()
    {
        ammo = GetComponent<Ammo>();
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && CanFire())
        {
            reloading = true;
            ammo.Use();
            SpawnArrow();
            StartCoroutine(Reloading());
        }
    }

    private void SpawnArrow()
    {
        var arrow = Instantiate(arrowPrefab, transform);
        arrow.Set();
    }

    private bool CanFire()
    {
        return !reloading && ammo.IsNotEmpty();
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }
}
