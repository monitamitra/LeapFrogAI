using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnObject
    {
        public GameObject preFab;
        [Range(0f, 1f)] public float spawnChance;
    }

    public SpawnObject[] spawnObjects;
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;
        foreach (var spawn in spawnObjects)
        {
            if (spawnChance < spawn.spawnChance)
            {
                GameObject obstacle = Instantiate(spawn.preFab);
                obstacle.transform.position += transform.position;
                break;
            }
            spawnChance -= spawn.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
