using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Arrow arrowPrefab;
    [SerializeField]private float reloadTime;
    private bool reloading = false;

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && CanFire())
        {
            reloading = true;
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
        return !reloading;
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }
}
