using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Creature creaturePrefab;
    [SerializeField]private float cooldownTime;
    private bool isCoolingDown = false;

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (isCoolingDown)
        {
            return;
        }

        isCoolingDown = true;
        var creature = Instantiate(creaturePrefab, transform);
        StartCoroutine(CoolingDown());
    }

    private IEnumerator CoolingDown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCoolingDown = false;
    }
}
