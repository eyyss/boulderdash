using System.Collections.Generic;
using UnityEngine;

public class MineralGenerator : MonoBehaviour
{
    public Rock rockPrefab;
    public Diamond diamondPrefab;
    public Vector2 spawnAreaX,spawnAreY;
    public float diamondSpawnChance = 0.3f;

    public int maxMineralSpawnCount;




    void Start()
    {
        for (int i = 0; i < maxMineralSpawnCount; i++)
        {
            SpawnMineral();
        }
    }

    public void SpawnMineral()
    {
        if (Random.value < diamondSpawnChance)
        {
            SpawnDiamond();
        }
        else
        {
            SpawnRock();
        }
    }
    void SpawnDiamond()
    {
        Vector3 randomPosition = GetRandomPosition();
        Instantiate(diamondPrefab, randomPosition, Quaternion.identity);

    }

    void SpawnRock()
    {
        Vector3 randomPosition = GetRandomPosition();
        Instantiate(rockPrefab, randomPosition, Quaternion.identity);

    }

    Vector3 GetRandomPosition()
    {
        int randomX = Random.Range((int)spawnAreaX.x , (int)spawnAreaX.y );
        int randomY = Random.Range((int)spawnAreY.x, (int)spawnAreY.y);
        return new Vector3(randomX+0.5f, randomY+0.5f, 0);
    }
}
