using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Arrow arrowPrefab;
    [SerializeField] private int baseDamage;
    [SerializeField] private float critPercentage;
    [SerializeField] private float critMultiplier;
    [SerializeField] private float arrowSpeed;
    [SerializeField] private float reloadTime;
    private int currentDamage;
    private float currentCritPercentage;
    private float currentCritMultiplier;
    private float currentArrowSpeed;
    private float currentReloadTime;
    private bool reloading = false;
    private Ammo ammo;

    private void Awake()
    {
        ammo = GetComponent<Ammo>();
        SetCurrentStats();
    }

    private void SetCurrentStats()
    {
        currentDamage = baseDamage;
        currentCritPercentage = critPercentage;
        currentCritMultiplier = critMultiplier;
        currentArrowSpeed = arrowSpeed;
        currentReloadTime = reloadTime;
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
        arrow.Set(currentDamage, currentCritPercentage, currentCritMultiplier, currentArrowSpeed);
    }

    private bool CanFire()
    {
        return !reloading && ammo.IsNotEmpty();
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(currentReloadTime);
        reloading = false;
    }

    public void IncreaseCrit(float crit)
    {
        currentCritPercentage = Mathf.Min(100, currentCritPercentage + crit);
    }

    public void ReduceReload(float time)
    {
        currentReloadTime = Mathf.Max(0, currentReloadTime - time);
    }

    public void IncreaseArrowSpeed(float speed)
    {
        currentArrowSpeed += speed;
    }
}
