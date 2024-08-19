using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct WaveEntry
{
    public Creature creature;
    public int number;
}

[Serializable]
public struct WaveEntry_
{
    public List<WaveEntry> creatures;
}

public class Spawner : MonoBehaviour
{
    public List<WaveEntry> waves = new List<WaveEntry>();
    [SerializeField]private float cooldownTime;
    private int waveIndex = 0;
    private bool isSpawning = false;
    private int waveCount = 1;

    private void Awake()
    {
        GetComponentInChildren<WaveUI>().SetText(0);
    }

    public void SpawnNextWave()
    {
        if (isSpawning || MonstersStillAlive())
        {
            return;
        }

        FindObjectOfType<Ammo>().Refill();
        GetComponentInChildren<WaveUI>().SetText(waveCount);
        isSpawning = true;
        StartCoroutine(SpawningWave());
    }

    public bool IsRunning() { return isSpawning; }

    private bool MonstersStillAlive()
    {
        return FindObjectsOfType<Creature>().Length > 0;
    }

    private IEnumerator SpawningWave()
    {
        for (int i = 0; i < waves[waveIndex].number; i++)
        {
            Spawn(waves[waveIndex].creature);
            yield return new WaitForSeconds(cooldownTime);
        }

        IncreaseWaveCount();
        isSpawning = false;
    }

    private void IncreaseWaveCount()
    {
        waveCount++;
        waveIndex = Mathf.Min(waveIndex + 1, waves.Count - 1);
    }

    private void Spawn(Creature creature)
    {
        var spawnedCreature = Instantiate(creature, transform);
    }
}
